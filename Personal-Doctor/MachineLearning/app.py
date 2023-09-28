from flask import Flask, request, jsonify
from data_processor import fetch_data_from_database, get_possible_illnesses_ranked
from flask_cors import CORS


app = Flask(__name__)

CORS(app, resources={r"*": {"origins": "*"}})

@app.route('/get_illnesses', methods=['POST'])
def get_illnesses():
    symptoms_input = request.json.get('symptoms', [])
    ranked_illnesses = get_possible_illnesses_ranked(symptoms_input, symptom_to_info)
    
    if ranked_illnesses:
        total_symptoms = len(symptoms_input)
        results = []
        for illness, (count, treatment, food) in ranked_illnesses:
            probability = (count / total_symptoms) * 100
            results.append({
                "illness": illness,
                "probability": probability,
                "treatment": treatment,
                "food": food
            })
        return jsonify(results)
    else:
        return jsonify([])

if __name__ == "__main__":
    symptom_to_info = fetch_data_from_database()
    app.run(host='0.0.0.0', port=5000)