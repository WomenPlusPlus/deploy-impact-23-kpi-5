from flask import Blueprint

index = Blueprint('index', __name__)


@index.route("/")
def index_route():
    return "API is running"
