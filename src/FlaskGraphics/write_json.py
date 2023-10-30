import json
from flask import jsonify, current_app, request, render_template
from utils import *

write_json = Blueprint('writeJson', __name__)


def generate_xlabel(years, months):
    month_dict = {1: "Jan", 2: "Feb", 3: "Mär", 4: "Apr", 5: "Mai", 6: "Jun",
                  7: "Jul", 8: "Aug", 9: "Sep", 10: "Okt", 11: "Nov", 12: "Dez"}

    return [str(month_dict[month]) + str(year)[-2:] for month, year in zip(months, years)]


@write_json.route('/generate_linechart/<kpi_id>', methods=['GET'])
def generate_linechart(kpi_id="854e5ab3-a091-44fc-949c-f6fc88d2ca19", timefrom=(2021, 1), timeto=(2023, 12)):
    with current_app.app_context():
        name = query_kpi_name(kpi_id)[0]["Name"]
        df = get_pandas_history(kpi_id, timefrom=timefrom, timeto=timeto)

        xs = generate_xlabel(df["PeriodYear"], df["PeriodMonth"])
        vals = list(df["Value"])

        data = {"xs": xs, "vals": vals, "name": name}

        return render_template('linechart.html', data_line=data)


@write_json.route('/generate_barchart', methods=['GET'])
@write_json.route('/generate_barchart/', methods=['GET'])
def generate_barchart(kpi_ids=["854e5ab3-a091-44fc-949c-f6fc88d2ca19", "6a9d1286-0654-4c79-b247-6f558539ab8d", "5b3a6f15-f847-4f9e-9000-bbf35469a88e"]):
    """
    Return current growth of all KPIs in the circle
    Use case: bar chart

    Parameter: kpis: list of dictionaries returned by user_choice
    """

    curr_growth, names = [], []

    for kpi_id in kpi_ids:
        name = query_kpi_name(kpi_id)[0]["Name"]
        names.append(name)
        _, curr = get_growth_rate(kpi_id, mode="current")
        curr_growth.append(curr)

    data = {"xs": names, "vals": curr_growth}

    return render_template('barchart.html', data_bar=data)
    

@write_json.route('/generate_multibarchart', methods=['GET'])
@write_json.route('/generate_multibarchart/', methods=['GET'])
def generate_multibarchart(kpi_ids=["854e5ab3-a091-44fc-949c-f6fc88d2ca19", "6a9d1286-0654-4c79-b247-6f558539ab8d", "5b3a6f15-f847-4f9e-9000-bbf35469a88e"],
                        years=[2022, 2023]):
    
    names = []
    for kpi_id in kpi_ids:
        names.append(query_kpi_name(kpi_id)[0]["Name"])

    vals = annual_average_growth(kpi_ids, years=years)

    data = {"xs": names, "vals": vals, "years": years}

    return render_template('multibarchart.html', data_multi=data)
    
