import mysql.connector
from mysql.connector import Error

def fetch_data_from_database():
    symptom_to_info = {}
    
    try:
        connection = mysql.connector.connect(host='fs213.sepe21.de', database='Projektseminar', user='root', password='geheim',ssl_disabled='True')
        if connection.is_connected():
            cursor = connection.cursor()
            query = "SELECT Symptom, Possible_illness, treatment, food FROM Symptome"  # Ersetzen Sie 'your_table_name' mit dem Namen Ihrer Tabelle
            cursor.execute(query)
            records = cursor.fetchall()
            
            for record in records:
                symptom, possible_illness, treatment, food = record
                if symptom not in symptom_to_info:
                    symptom_to_info[symptom] = []
                symptom_to_info[symptom].append((possible_illness, treatment, food))
                
    except Error as e:
        print("Error while connecting to MySQL", e)
    finally:
        if connection.is_connected():
            cursor.close()
            connection.close()
    
    return symptom_to_info

def get_possible_illnesses_ranked(symptoms, symptom_to_info):
    illness_count = {}
    for symptom in symptoms:
        for illness, treatment, food in symptom_to_info.get(symptom, []):
            if illness not in illness_count:
                illness_count[illness] = (0, treatment, food)
            count, _, _ = illness_count[illness]
            illness_count[illness] = (count + 1, treatment, food)

    sorted_illnesses = sorted(illness_count.items(), key=lambda x: x[1][0], reverse=True)
    return sorted_illnesses

symptom_to_info = fetch_data_from_database()
symptoms_input = input("Bitte geben Sie die Symptome ein, getrennt durch Komma (z.B. Fieber, Husten): ")
symptoms = [s.strip() for s in symptoms_input.split(',')]
ranked_illnesses = get_possible_illnesses_ranked(symptoms, symptom_to_info)

if ranked_illnesses:
    print("\nMögliche Krankheiten basierend auf Ihren Symptomen:")
    print('-' * 80)
    print("{:<30} {:<20} {:<15} {:<10}".format("Krankheit", "Wahrscheinlichkeit", "Behandlung", "Lebensmittel"))
    print('-' * 80)
    
    total_symptoms = len(symptoms)
    for illness, (count, treatment, food) in ranked_illnesses:
        probability = (count / total_symptoms) * 100
        print("{:<30} {:<20.2f}% {:<15} {:<10}".format(illness, probability, treatment, food))
else:
    print("Keine Daten für diese Symptome gefunden.")
