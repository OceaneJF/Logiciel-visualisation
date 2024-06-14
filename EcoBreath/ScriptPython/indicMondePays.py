import matplotlib.pyplot as plt
import pymssql
import pandas as pd
import sys
import geopandas as gpd

image_chemin=sys.argv[1]

cnxn = pymssql.connect ( server = 'info-mssql-etd', user = 'etd14', password = 'x578tcb5', database = 'BDEquipe14' )

indicator = 'select * from T_INDICATOR_IND'
country = 'select * from T_COUNTRY_CTR'

world = gpd.read_file(gpd.datasets.get_path('naturalearth_lowres'))

df_ind = pd.read_sql(indicator,cnxn,coerce_float=False)
df_count = pd.read_sql(country,cnxn,coerce_float=False)

date=sys.argv[2]
date = int(date)
indicator_value=sys.argv[3]


df_date_and_pop = df_ind.merge(df_count,
                                left_on='CTR_ID',
                                right_on='CTR_ID',
                                how='inner', validate="many_to_many")[['CTR_ID', 'IND_' + indicator_value, 'IND_YEAR']]
df = df_date_and_pop[df_date_and_pop['IND_YEAR'] == date]
df = df.drop(["IND_YEAR"], axis=1)

if indicator_value == "POPULATION":
        df['IND_POPULATION'] /= 1e6  # Convertir en milliards d'euros
if indicator_value == "GDP":
    df['IND_GDP'] /= 1e9  # Convertir en milliards d'euros

world = world.rename(columns={'iso_a3': 'CTR_ID'})

merged = world.merge(df, on='CTR_ID')

fig, ax = plt.subplots(1, 1, figsize=(12, 8))

ax.set_axis_off()

config = {
    "POPULATION": {
        "legend_kwds": {'label': "Population en millions de personnes", 'orientation': "horizontal"},
        "title": "Carte choroplèthe de la population par pays",
    },
    "GDP": {
        "legend_kwds": {'label': "PIB par pays en milliards d'euros", 'orientation': "horizontal"},
        "title": "Carte choroplèthe du Produit Intérieur Brut (PIB) par pays",
    },
    "GHG": {
        "legend_kwds": {'label': "GES en kt co2 eq", 'orientation': "horizontal"},
        "title": "Carte choroplèthe des émissions de Gaz à Effet de Serre (GES)",
    },
}

if indicator_value in config and 'IND_' + indicator_value in merged.columns:
    cfg = config[indicator_value]
    min_value = merged['IND_' + indicator_value].min()
    max_value = merged['IND_' + indicator_value].max()
    
    norm = plt.Normalize(min_value, max_value)
    sm = plt.cm.ScalarMappable(norm=norm)
    sm.set_array([])

    merged.plot(column='IND_' + indicator_value, ax=ax, legend=False, norm=norm)

    cbar = fig.colorbar(sm, ax=ax, orientation=cfg["legend_kwds"]["orientation"], pad=0.01, fraction=0.05)
    cbar.set_label(cfg["legend_kwds"]["label"], fontsize=12)
    ax.set_title(cfg["title"], fontsize=19)
else:
    print(f"Configuration ou colonne pour {indicator_value} non trouvée")


plt.savefig(image_chemin,transparent=True)
plt.close()
cnxn.close()