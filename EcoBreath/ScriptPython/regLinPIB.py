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
df=df.drop(["IND_POPULATION","IND_ID"],axis=1)

# On regroupe les données par année et on calcul les totaux (somme des données de tous les pays)
df_grouped = df.groupby('IND_YEAR').agg({
    'IND_GHG': 'sum',
    'IND_GDP': 'sum'
}).reset_index()

# On renome les colonnes pour mieux comprendre 
df_grouped.columns = ['Année', 'Emissions_CO2_Totales', 'PIB']
df_grouped.sort_values(["Année"],ascending=[True])

# On enlève toutes les lignes dont les années sont inférieur à 1990 et supérieur à 2020
df_grouped = df_grouped[(df_grouped['Année'] >= 1990) & (df_grouped['Année'] <= 2020)]

# extravtion des colonnes nécessaires
pib_total = df_grouped['PIB']
emissions_total = df_grouped['Emissions_CO2_Totales']

# On réalise la régression linéaire
slope, intercept, r_value, p_value, std_err = stats.linregress(pib_total, emissions_total)
# On affiche la courbe de régression linéaire 
plt.scatter(pib_total, emissions_total, label='Données observées')
plt.plot(pib_total, intercept + slope * pib_total, 'r', label='Droite de régression')
plt.xlabel('PIB Totale US $')
plt.ylabel('Émissions de CO2 Totales en kt')
plt.legend()
plt.title('Régression linéaire des émissions de CO2 par rapport au PIB totale')
plt.savefig(output_image_path,transparent=True)
plt.close()
cnxn.close()