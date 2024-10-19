import sys
import json
import torch
from transformers import pipeline, logging

# Ensure warnings are not logged
logging.set_verbosity(logging.CRITICAL)

# Load the model and tokenizer (Update with correct paths if necessary)
model_name = "aboonaji/llama2finetune-v2"
tokenizer_name = "aboonaji/llama2finetune-v2"

# Initialize the text generation pipeline
pipe = pipeline(
    task="text-generation",
    model=model_name,
    tokenizer=tokenizer_name,
    max_length=100
)

def generate_llama(prompt):
    """Generates a response using the LLaMA model."""
    result = pipe(f"<s>[INST] {prompt} [/INST]")
    answer = result[0]['generated_text']

    # Extract relevant part after the instruction token
    split_response = answer.split('[/INST]')
    retval = split_response[1].strip() if len(split_response) > 1 else answer
    return retval

if __name__ == "__main__":
    # Read prompt from the command line argument
    prompt = sys.argv[1]
    response = generate_llama(prompt)
    print(json.dumps({"response": response}))
