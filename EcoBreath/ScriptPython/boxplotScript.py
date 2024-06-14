import matplotlib.pyplot as plt
import pymssql
import pandas as pd
import sys
import geopandas as gpd

output_image_path=sys.argv[1]

# Connexion à la base de données
cnxn = pymssql.connect(server='info-mssql-etd', user='etd14', password='x578tcb5', database='BDEquipe14')

# Requêtes SQL
indicator = 'select * from T_INDICATOR_IND'
country = 'select * from T_COUNTRY_CTR'

# Transformation en dataframe
df_ind = pd.read_sql(indicator, cnxn, coerce_float=False)
df_count = pd.read_sql(country, cnxn, coerce_float=False)

#Il y a deux parametres la date et l'indicateur (pop,pib,ghg)
date=sys.argv[3]
date=int(date)
indicator=sys.argv[2]

# On fusionne les DataFrames et on sélectionne les colonnes nécessaires
df_date_and_pop = df_ind.merge(df_count, left_on='CTR_ID', right_on='CTR_ID', how='inner')[['CTR_ID', 'IND_'+indicator.upper(), 'IND_YEAR']]
df = df_date_and_pop[df_date_and_pop['IND_YEAR'] == date]
df = df.drop(["IND_YEAR"], axis=1)

# On détermine la valeur min, max , moyenne et les quartiles 
min_val = df['IND_'+indicator.upper()].min()
max_val = df['IND_'+indicator.upper()].max()
mean_val = df['IND_'+indicator.upper()].mean()
quartiles = df['IND_'+indicator.upper()].quantile([0.25, 0.5, 0.75])

max_label = f'{max_val}'

# On enlève toutes les valeurs abérrante du boxplot et aussi la valeur max 
df_filtered = df[df['IND_'+indicator.upper()] != max_val]
fig, ax = plt.subplots(figsize=(10, 6))
df_filtered.boxplot(column='IND_'+indicator.upper(), ax=ax, showfliers=False)
ax.set_title('Boxplot de '+indicator+' par pays en '+str(date),fontsize=30)
ax.set_ylabel(indicator, fontsize=20)

# On affiche les statistiques sur le boxplot
ax.scatter(1, min_val, color='red', label='Min', zorder=5)  
ax.scatter(1, mean_val, color='blue', label='Mean', zorder=5)  

# On ajoute des annotations pour les points
ax.annotate(f'Min: {min_val}', xy=(1, min_val), xytext=(1.1, min_val), ha='left', va='center', color='red')
ax.annotate(f'Mean: {mean_val:.2f}', xy=(1, mean_val), xytext=(1.1, mean_val), ha='left', va='center', color='blue')

# On ajoute la valeur maximale à la légende
handles, labels = ax.get_legend_handles_labels()
handles.append(plt.Line2D([0], [0], marker='o', color='w', markerfacecolor='green', markersize=10))
labels.append(f'Max: {max_label}')
ax.legend(handles, labels, loc='best')

plt.savefig(output_image_path,transparent=True)
plt.close()
cnxn.close()