import matplotlib.pyplot as plt
import pymssql
import pandas as pd
import sys

output_image_path=sys.argv[1]

# Connexion à la base de données
cnxn = pymssql.connect(server='info-mssql-etd', user='etd14', password='x578tcb5', database='BDEquipe14')

# Requêtes SQL
indicator = 'select * from T_INDICATOR_IND'
country = 'select * from T_COUNTRY_CTR'
region_pays = 'select * from IS_ON'
region = 'select * from T_REGION_REG'

# Transformation en dataframe
df_ind = pd.read_sql(indicator, cnxn, coerce_float=False)
df_count = pd.read_sql(country, cnxn, coerce_float=False)
df_regionPays = pd.read_sql(region_pays, cnxn, coerce_float=False)
df_region = pd.read_sql(region, cnxn, coerce_float=False)

#Il y a deux parametres , la date et l'indicateur choisit
indicator=sys.argv[3]
date=sys.argv[2]
date = int(date)


# On renome les région pour qu'elle corresponde à celles de geopandas
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

#fonction qui permet d'enlever les espaces e, trop
def clean_string(value):
    return value.strip()

# On enlève les espaces en trop de toutes les régions
for index, row in df_region.iterrows():
    df_region.at[index, 'REG_NAME'] = clean_string(row['REG_NAME'])

df_region['REG_NAME'] = df_region['REG_NAME'].replace(rename_regions)

# On fusionne les DataFrames pour obtenir une seule table avec toutes les informations nécessaires
merged_df = pd.merge(df_regionPays, df_region, on='REG_ID')
merged_df = pd.merge(merged_df, df_count, on='CTR_ID')
merged_df = pd.merge(merged_df, df_ind, on='CTR_ID')

# On choisit la date 
merged_df = merged_df[merged_df['IND_YEAR'] == date]
print(merged_df)
# On calcul la population ou le pib ou le ghg (celon ce qui a été choisit) totale par région pour l'année choisit
region_population = merged_df.groupby('REG_NAME')['IND_'+indicator.upper()].sum().reset_index()
print(region_population)
#On affiche le diagramme de secteur
fig, ax = plt.subplots(figsize=(10, 10))
ax.pie(region_population['IND_'+indicator.upper()], labels=region_population['REG_NAME'], autopct='%1.1f%%', startangle=90,textprops={'fontsize': 16})
ax.axis('equal') 
plt.title('Diagramme représentant la répartition de '+indicator.upper()+' \n par region en '+ str(date), fontsize=25 )
plt.savefig(output_image_path,transparent=True)
plt.close()
cnxn.close()