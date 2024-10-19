import sys
import json
from transformers import pipeline

# Load your model and tokenizer
model_name = "path/to/your/model"  # Adjust the path to your model
tokenizer_name = "path/to/your/tokenizer"  # Adjust the path to your tokenizer

pipe = pipeline(task="text-generation", model=model_name, tokenizer=tokenizer_name, max_length=100)

def generate_response(prompt):
    result = pipe(f"<s>[INST] {prompt} [/INST]")
    return result[0]['generated_text']

if __name__ == "__main__":
    prompt = sys.argv[1]
    response = generate_response(prompt)
    print(json.dumps({"response": response}))
