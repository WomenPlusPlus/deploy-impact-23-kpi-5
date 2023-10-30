import os


from flask import Flask

from index import index
from write_json import write_json

app = Flask(__name__)
app.secret_key = os.environ.get("APP_SECRET_KEY")

app.register_blueprint(index)
app.register_blueprint(write_json)

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=8000)
