import matplotlib.pyplot as plt
import pymssql
import pandas as pd
import geopandas as gpd
import sys
image_chemin=sys.argv[1]

# Connexion à la base de données
cnxn = pymssql.connect(server='info-mssql-etd', user='etd14', password='x578tcb5', database='BDEquipe14')

# Requêtes SQL
indicator = 'select * from T_INDICATOR_IND'
country = 'select * from T_COUNTRY_CTR'

# Lecture des données géographiques
world = gpd.read_file(gpd.datasets.get_path('naturalearth_lowres'))

# Lecture des données à partir de la base de données
df_ind = pd.read_sql(indicator, cnxn, coerce_float=False)
df_count = pd.read_sql(country, cnxn, coerce_float=False)

indicator_value = sys.argv[2]
pays_id = sys.argv[3]

# Fusion des données sur l'indicateur et le pays
df_date_and_pop = df_ind.merge(df_count,
                               left_on='CTR_ID',
                               right_on='CTR_ID',
                               how='inner', validate="many_to_many")[['CTR_ID', 'IND_' + indicator_value, 'IND_YEAR']]
df = df_date_and_pop[df_date_and_pop['CTR_ID'] == pays_id]

# Conversion des valeurs en fonction de l'indicateur
if indicator_value == "POPULATION":
    df['IND_' + indicator_value] /= 1e6  # Convertir en millions de personnes
if indicator_value == "GDP":
    df['IND_GDP'] /= 1e9  # Convertir en milliards d'euros

nom_pays = df_count.loc[df_count['CTR_ID'] == pays_id, 'CTR_NAME'].values[0]

# Configuration des légendes et titres pour chaque indicateur
config = {
    "POPULATION": {
        "ylabel": "Population (millions)",
        "title": "Évolution de la population par année en "+nom_pays,
    },
    "GDP": {
        "ylabel": "PIB (milliards d'euros)",
        "title": "Évolution du Produit Intérieur Brut (PIB) par année en "+nom_pays,
    },
    "GHG": {
        "ylabel": "GES (kt équivalent CO2)",
        "title": "Évolution des émissions de Gaz à Effet de Serre (GES) par année en "+nom_pays,
    },
}

# Création du graphique linéaire
fig, ax = plt.subplots(figsize=(10, 6))

if indicator_value in config and 'IND_' + indicator_value in df.columns:
    cfg = config[indicator_value]
    
    df.plot(kind='line', x='IND_YEAR', y='IND_' + indicator_value, ax=ax, legend=False)
    
    ax.set_xlabel('Année', fontsize=12)
    ax.set_ylabel(cfg["ylabel"], fontsize=12)
    ax.set_title(cfg["title"], fontsize=15)
else:
    print(f"Configuration ou colonne pour {indicator_value} non trouvée")

plt.savefig(image_chemin,transparent=True)
plt.close()
cnxn.close()
