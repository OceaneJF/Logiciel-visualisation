import matplotlib.pyplot as plt
import pymssql
import pandas as pd
import geopandas as gpd
import sys

output_image_path=sys.argv[1]
# Connexion à la base de données
cnxn = pymssql.connect(server='info-mssql-etd', user='etd14', password='x578tcb5', database='BDEquipe14')

# Requêtes SQL
indicator = 'select * from T_INDICATOR_IND'
country = 'select * from T_COUNTRY_CTR'
region_pays = 'select * from IS_ON'
region = 'select * from T_REGION_REG'

# On transforme en dataframe 
df_ind = pd.read_sql(indicator, cnxn, coerce_float=False)
df_count = pd.read_sql(country, cnxn, coerce_float=False)
df_regionPays = pd.read_sql(region_pays, cnxn, coerce_float=False)
df_region = pd.read_sql(region, cnxn, coerce_float=False)

#Il y a deux parametres , la region et l'indicateur choisit
region=sys.argv[3]
if region == "North_America" or region == "South_America":
    region = region.replace("_"," ")

indicator=sys.argv[2]

# On renomme les sous-region
rename_regions = {
    'asia_west': 'Asia',
    'east_asia_pacific': 'Oceania',
    'europe_east': 'Europe',
    'europe_west': 'Europe',
    'africa_north': 'Africa',
    'africa_sub_saharan': 'Africa',
    'america_north': 'North America',
    'america_south': 'South America'
}

#fonction qui retire les espaces en trop
def clean_string(value):
    return value.strip()

# On retire les espaces en trop
for index, row in df_region.iterrows():
    df_region.at[index, 'REG_NAME'] = clean_string(row['REG_NAME'])

df_region['REG_NAME'] = df_region['REG_NAME'].replace(rename_regions)

# On fusionne les DataFrames pour obtenir une seule table avec toutes les informations nécessaires
merged_df = pd.merge(df_regionPays, df_region, on='REG_ID')
merged_df = pd.merge(merged_df, df_count, on='CTR_ID')
merged_df = pd.merge(merged_df, df_ind, on='CTR_ID')

print(merged_df)

# On choisit la region
df = merged_df[merged_df['REG_NAME'] == region]

# On calcul la population totale par année pour la région choisit
df_by_year = df.groupby('IND_YEAR')['IND_'+indicator.upper()].sum().reset_index()

#On change la légende en fonction de l'indicateur choisit et on affiche la carte 
config = {
    "POPULATION": {
        "legend_kwds": {'label': "Population en milliard pour "+region, 'orientation': "horizontal"},
        "title": "Graphique représentant la variation de la population au cours du temps pour "+region
    },
    "GDP": {
        "legend_kwds": {'label': "PIB en milliard pour "+region, 'orientation': "horizontal"},
        "title": "Graphique représentant la variation du PIB pour "+region
    },
    "GHG": {
        "legend_kwds": {'label': "Emission en co2 en tonne pour "+region, 'orientation': "horizontal"},
        "title": "Graphique représentant la variation des emissions en co2 pour "+region
    }
}
# On selectionne la clé de configuration souhaitée
config_key = indicator  

# Affichage du graphique
fig, ax = plt.subplots(figsize=(10, 7))
ax.plot(df_by_year['IND_YEAR'], df_by_year['IND_'+indicator.upper()], linestyle='-', color='b')

# On applique les légendes et le titre en fonction de la configuration
cfg = config[config_key]
ax.set_xlabel('Année')
ax.set_ylabel(cfg['legend_kwds']['label'] )
ax.set_title(cfg['title'])

plt.savefig(output_image_path,transparent=True)
plt.close()
cnxn.close()