import pandas as pd
from scipy import stats
import numpy as np
import matplotlib.pyplot as plt
import pymssql
import sys


output_image_path=sys.argv[1]
#Connection à la base
cnxn = pymssql.connect ( server = 'info-mssql-etd', user = 'etd14', password = 'x578tcb5', database = 'BDEquipe14' )

#Récupération de la table 
indicator = 'select * from T_INDICATOR_IND'
#Transformation en dataframe
df= pd.read_sql(indicator,cnxn,coerce_float=False)
#On enlève les colonnes inutiles
df=df.drop(["IND_GDP","IND_ID"],axis=1)

# On regroupe les données par année et on calcul les totaux (somme des données de tous les pays)
df_grouped = df.groupby('IND_YEAR').agg({
    'IND_GHG': 'sum',
    'IND_POPULATION': 'sum'
}).reset_index()

# On renome les colonnes pour mieux comprendre 
df_grouped.columns = ['Année', 'Emissions_CO2_Totales', 'Population_Totale']
df_grouped.sort_values(["Année"],ascending=[True])

# On enlève toutes les lignes dont les années sont inférieur à 1990 et supérieur à 2020
df_grouped = df_grouped[(df_grouped['Année'] >= 1990) & (df_grouped['Année'] <= 2020)]

# extravtion des colonnes nécessaires
population_total = df_grouped['Population_Totale']
emissions_total = df_grouped['Emissions_CO2_Totales']

# On réalise la régression linéaire
slope, intercept, r_value, p_value, std_err = stats.linregress(population_total, emissions_total)

# On affiche la courbe de régression linéaire 
plt.scatter(population_total, emissions_total, label='Données observées')
plt.plot(population_total, intercept + slope * population_total, 'r', label='Droite de régression')
plt.xlabel('Population Totale US $')
plt.ylabel('Émissions de CO2 Totales en kt')
plt.legend()
plt.title('Régression linéaire des émissions de CO2 par rapport à la population totale')
plt.savefig(output_image_path,transparent=True)
plt.close()
cnxn.close()