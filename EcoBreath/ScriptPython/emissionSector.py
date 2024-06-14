import matplotlib.pyplot as plt
import pymssql
import pandas as pd
import sys
import geopandas as gpd

output_image_path=sys.argv[1]
# Connexion à la base de données
cnxn = pymssql.connect(server='info-mssql-etd', user='etd14', password='x578tcb5', database='BDEquipe14')

# Requêtes SQL
have = 'select * from HAVE'
country = 'select * from T_COUNTRY_CTR'
sector = 'select * from T_SECTOR_SCT'

#Transformation en dataframe
df_emission = pd.read_sql(have,cnxn,coerce_float=False)
df_country = pd.read_sql(country,cnxn,coerce_float=False)
df_sector = pd.read_sql(sector,cnxn,coerce_float=False)

#le pays est un parametre 
pays=sys.argv[2]

#On fusionne les DataFrames pour obtenir une seule table avec toutes les informations nécessaires
merged_df = pd.merge(df_emission, df_country, on='CTR_ID')
merged_df = pd.merge(merged_df, df_sector, on='SCT_ID')

# On choisit le pays
france_df = merged_df[merged_df['CTR_ID'] == pays]

#On calcul les émissions de CO2 par secteur et par année
emission_by_sector_year = france_df.pivot_table(values='CO2EMISSION', index='SECTORYEAR', columns='SCT_NAME', aggfunc='sum', fill_value=0)

#nomPays = emission_by_sector_year.loc[emission_by_sector_year['CTR_ID'] == pays, 'CTR_NAME'].value[0]
# On affiche le graphique en aires empilées
fig, ax = plt.subplots(figsize=(12, 8))
emission_by_sector_year.plot(kind='area', stacked=True, ax=ax, colormap='viridis')
ax.set_xlabel('Année')
ax.set_ylabel('Émissions de CO2 (en kg)')
ax.set_title('Émissions de CO2 par secteur en '+pays+' au fil des années')
plt.legend(title='Secteur', bbox_to_anchor=(0.5, -0.2), loc='upper center', ncol=3)
plt.tight_layout()
plt.savefig(output_image_path,transparent=True)
plt.close()
cnxn.close()