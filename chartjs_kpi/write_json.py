import pandas as pd
import numpy as np
import json
import os
from supabase import create_client, Client

from utils import *

url: str = os.environ.get("SUPABASE_URL")
key: str = os.environ.get("SUPABASE_KEY")
supabase: Client = create_client(url, key)


def generate_xlabel(years, months):
    month_dict = {1: "Jan", 2: "Feb", 3: "Mär", 4: "Apr", 5: "Mai", 6: "Jun", 
                  7: "Jul", 8: "Aug", 9: "Sep", 10: "Okt", 11: "Nov", 12: "Dez"}
    
    return [str(month_dict[month]) + str(year)[-2:] for month, year in zip(months, years)]


def generate_linechart(kpi_id, timefrom=(2023,1), timeto=(2023,12), fname="src/linedata.json"):
    name = query_kpi_name(kpi_id)[0]["Name"]
    df = get_pandas_history(kpi_id, timefrom=timefrom, timeto=timeto)

    xs = generate_xlabel(df["PeriodYear"], df["PeriodMonth"])
    vals = list(df["Value"])

    with open(fname, 'w') as f:
        json.dump({"xs": xs, "vals": vals, "name": name}, f)


def generate_barchart(kpi_ids, fname="src/bardata.json"):
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
    
    with open(fname, 'w') as f:
        json.dump({"xs": names, "vals": curr_growth}, f)
    

def generate_multibarchart(kpi_ids, 
                           years=[2022, 2023], 
                           fname="src/multibardata.json"):
    
    names = []
    for kpi_id in kpi_ids:
        names.append(query_kpi_name(kpi_id)[0]["Name"])

    vals = annual_average_growth(kpi_ids, years=years)

    with open(fname, 'w') as f:
        json.dump({"xs": names, "vals": vals, "years": years}, f)
    

circles = supabase.table("Circle").select("id").execute().data
circle_ids = [c["id"] for c in circles]
test_id = circle_ids[0]

kpis = query_kpi(test_id).data
kpi_ids = [k["id"] for k in kpis]


generate_linechart(kpi_ids[0], timefrom=(2021,1), timeto=(2023,12))
generate_barchart(kpi_ids)
generate_multibarchart(kpi_ids)





    




