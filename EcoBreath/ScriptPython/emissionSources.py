import matplotlib.pyplot as plt
import pymssql
import pandas as pd
import sys
import geopandas as gpd

output_image_path=sys.argv[1]

# Connexion à la base de données
cnxn = pymssql.connect(server='info-mssql-etd', user='etd14', password='x578tcb5', database='BDEquipe14')

# Requêtes SQL
canUse = 'select * from CAN_USE'
country = 'select * from T_COUNTRY_CTR'
sources = 'select * from T_ENERGYSOURCE_ENS'

#On transforme en dataframe
df_emissions = pd.read_sql(canUse,cnxn,coerce_float=False)
df_countries = pd.read_sql(country,cnxn,coerce_float=False)
df_sources = pd.read_sql(sources,cnxn,coerce_float=False)

#le parametre est un pays
pays=sys.argv[2]

#On enlève les colonnes inutiles
df_emissions=df_emissions.drop(["ENSCONSUMPTION","ENSPRODUCTION"],axis=1)

# On fusionne les DataFrames pour obtenir toutes les informations nécessaires
merged_df = pd.merge(df_emissions, df_countries, on='CTR_ID')
merged_df = pd.merge(merged_df, df_sources, on='ENS_ID')

# On ajoute une colonne pour indiquer si la source est fossile ou non
merged_df['ENS_NAME'] = merged_df.apply(lambda x: f"{x['ENS_NAME']} (Fossil)" if x['ENS_ISFOSSIL'] else f"{x['ENS_NAME']} (Non-Fossil)", axis=1)

# On choisit le pays
df = merged_df[merged_df['CTR_ID'] == pays]

# On calcul la quantité totale d'émissions de CO2 par source et par année
co2_by_year_source = df.pivot_table(index='SOURCEYEAR', columns='ENS_NAME', values='CO2EMISSION', aggfunc='sum', fill_value=0)

# On affiche le graphique en aires empilées
fig, ax = plt.subplots(figsize=(12, 8))
co2_by_year_source.plot(kind='area', stacked=True, ax=ax, colormap='viridis')
ax.set_xlabel('Année')
ax.set_ylabel('Émissions de CO2 (en kg)')
ax.set_title('Émissions de CO2 par source en '+pays)
plt.legend(title='Source', bbox_to_anchor=(0.5, -0.2), loc='upper center', ncol=3)
plt.tight_layout()
plt.savefig(output_image_path,transparent=True)
plt.close()
cnxn.close()
