import matplotlib.pyplot as plt
import pymssql
import pandas as pd
import geopandas as gpd
import sys
image_chemin=sys.argv[1]

cnxn = pymssql.connect(server='info-mssql-etd', user='etd14', password='x578tcb5', database='BDEquipe14')

indicator_query = 'SELECT * FROM T_GEOGRAPHICALDATA_GEO'
country_query = 'SELECT * FROM T_COUNTRY_CTR'

geodata=sys.argv[2]

world = gpd.read_file(gpd.datasets.get_path('naturalearth_lowres'))

df_ind = pd.read_sql(indicator_query, cnxn, coerce_float=False)
df_geo = pd.read_sql(country_query, cnxn, coerce_float=False)

df_meantemp = df_ind.merge(df_geo, on='CTR_ID', how='inner', validate="many_to_many")[['CTR_ID', 'GEO_'+geodata, 'GEO_LAT', 'GEO_LON']]

geometry = gpd.points_from_xy(df_meantemp["GEO_LON"], df_meantemp["GEO_LAT"])

geo_temp = gpd.GeoDataFrame(df_meantemp, crs="EPSG:4326", geometry=geometry)
countries_with_data = df_geo['CTR_ID'].unique()
world_filtered = world[world['iso_a3'].isin(countries_with_data)]

fig, ax = plt.subplots(1, 1, figsize=(12, 8))
ax.set_axis_off()

base = world_filtered.boundary.plot(ax=ax, color='black',linewidth=0.5)  # Tracer les frontières des pays

config = {
    "MEANTEMP": {
        "legend_kwds": {'label': "Températures en °C", 'orientation': "horizontal"},
        "title": "Carte prévisionnelle (court terme) des températures moyennes",
    },
    "TX35": {
        "legend_kwds": {'label': "Durée en jours", 'orientation': "horizontal"},
        "title": "Carte prévisionnelle (court terme) du nombre de jours \n où la température dépassera 35°C",
    },
    "SEALVL": {
        "legend_kwds": {'label': "Niveau de la mer en mètres", 'orientation': "horizontal"},
        "title": "Carte prévisionnelle (court terme) du niveau de la mer",
    },
    "MEANTEMPCHANGE": {
        "legend_kwds": {'label': "Changements des températures en °C", 'orientation': "horizontal"},
        "title": "Carte prévisionnelle (court terme) des changements des températures moyennes",
    },
    "TOTALPRECIPIT": {
        "legend_kwds": {'label': "Précipitations en %", 'orientation': "horizontal"},
        "title": "Carte prévisionnelle (court terme) des précipitations",
    }
}

if geodata in config and 'GEO_'+geodata in geo_temp.columns:
    cfg = config[geodata]
    cmap = 'coolwarm'
    norm = plt.Normalize(vmin=geo_temp['GEO_'+geodata].min(), vmax=geo_temp['GEO_'+geodata].max())
    sm = plt.cm.ScalarMappable(cmap=cmap, norm=norm)
    sm.set_array([])
    
    geo_temp.plot(column='GEO_'+geodata, markersize=5, ax=ax, legend=False, cmap=cmap, norm=norm)
    cbar = fig.colorbar(sm, ax=ax, orientation=cfg["legend_kwds"]["orientation"],  pad=0.01, fraction=0.05)
    cbar.set_label(cfg["legend_kwds"]["label"], fontsize=12)
    ax.set_title(cfg["title"], fontsize=16)
else:
    print(f"Configuration ou colonne pour {geodata} non trouvée")



plt.savefig(image_chemin,transparent=True)
plt.close()
cnxn.close()