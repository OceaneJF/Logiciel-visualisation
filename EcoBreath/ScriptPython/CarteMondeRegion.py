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

# Transformer les données en dataframe
df_ind = pd.read_sql(indicator, cnxn, coerce_float=False)
df_count = pd.read_sql(country, cnxn, coerce_float=False)
df_regionPays = pd.read_sql(region_pays, cnxn, coerce_float=False)
df_region = pd.read_sql(region, cnxn, coerce_float=False)

#Il y a deux parametres la date et l'indicateur (pop,pib,ghg)
date=sys.argv[2]
date=int(date)
indicator=sys.argv[3]

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

#on enlève les espaces en trop
def clean_string(value):
    return value.strip()

# On enlève les espaces pour les noms des region
for index, row in df_region.iterrows():
    df_region.at[index, 'REG_NAME'] = clean_string(row['REG_NAME'])

df_region['REG_NAME'] = df_region['REG_NAME'].replace(rename_regions)

# On fusionne les DataFrames pour obtenir une seule table avec toutes les informations nécessaires
merged_df = pd.merge(df_regionPays, df_region, on='REG_ID')
merged_df = pd.merge(merged_df, df_count, on='CTR_ID')
merged_df = pd.merge(merged_df, df_ind, on='CTR_ID')

# On choisit l'année
merged_df = merged_df[merged_df['IND_YEAR'] == date]

# On calcul l'indicateur choisit par région pour l'année choisit
region_population = merged_df.groupby('REG_NAME')['IND_'+indicator.upper()].sum().reset_index()

# On charge la carte du monde
world = gpd.read_file(gpd.datasets.get_path('naturalearth_lowres'))

# On dissout les pays par continent pour obtenir des entités continentales
world = world.dissolve(by='continent')

# On fusionne la carte du monde avec les données de population par région
world = world.merge(region_population, left_on='continent', right_on='REG_NAME', how='left')

# On affiche la carte choroplèthe
fig, ax = plt.subplots(1, 1, figsize=(12, 8))
ax.set_axis_off()

#On change la légende en fonction de l'indicateur choisit et on affiche la carte 
config = {
    "POPULATION": {
        "legend_kwds": {'label': "Population en milliard", 'orientation': "horizontal"},
        "title": "Carte de la population par region"
    },
    "GDP": {
        "legend_kwds": {'label': "PIB en US $", 'orientation': "horizontal"},
        "title": "Carte du PIB totale par region"
    },
    "GHG": {
        "legend_kwds": {'label': "Emission en co2 en kt de CO2", 'orientation': "horizontal"},
        "title": "Carte des emission en co2 par region"
    }
}

if indicator in config and 'IND_'+indicator.upper() in world.columns:
    cfg = config[indicator]
    world.plot(column='IND_'+indicator.upper(), ax=ax, legend=False, edgecolor='black',linewidth=0.5)
    norm = plt.Normalize(vmin=world['IND_'+indicator.upper()].min(), vmax=world['IND_'+indicator.upper()].max())
    sm = plt.cm.ScalarMappable(cmap='viridis', norm=norm)
    sm.set_array([])
    cbar = fig.colorbar(sm, ax=ax, orientation=cfg["legend_kwds"]['orientation'], pad=0.01, fraction=0.05)  
    cbar.set_label(cfg["legend_kwds"]['label'], fontsize=12)
    plt.title(cfg["title"], fontsize=19)

plt.savefig(output_image_path,transparent=True)
plt.close()
cnxn.close()