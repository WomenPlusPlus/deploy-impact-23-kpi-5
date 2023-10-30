import pandas as pd
import datetime
from dotenv import load_dotenv
load_dotenv()
import os
from supabase import create_client, Client

url: str = os.environ.get("SUPABASE_URL")
key: str = os.environ.get("SUPABASE_KEY")
supabase: Client = create_client(url, key)


def query_circle():
    return supabase.table("Circle").select("*").execute()


def query_kpi(circle_id):
    """
    at the moment, it only returns the KPI ids
    maybe nice to have: info about value type/units and periodicity
    """
    return supabase.table("Kpi").select("id", "Name").eq("CircleId", str(circle_id)).execute()


def query_kpi_name(kpi_id):
    """
    return the kpi name given the kpi id
    """
    return supabase.table("Kpi").select("Name").eq("id", str(kpi_id)).execute().data


# def query_kpi_history(kpi_id, all_time=False, timefrom=(2023,1), timeto=(2023,12)):
def query_kpi_history(kpi_id):
    """
    Return a (sorted) history table for the specific Kpi in the specified time window.
    timefrom, timeto: tuple of (year, month)
    """

    return supabase.table("KpiHistory").select("Value", "PeriodYear", "PeriodMonth").eq(
    "KpiId", str(kpi_id)).execute()


def get_pandas_history(kpi_id, ascending=True):
    """
    Returns pandas Dataframe of the requested time window 
    Use cases: Vanilla Excel-style Table, line graph
    """

    return pd.DataFrame(query_kpi_history(kpi_id).
                        data).sort_values(["PeriodYear", "PeriodMonth"], 
                        ascending=ascending, ignore_index=True)


def get_years(kpi_id):
    """
    Return the second minimum (second earliest) and maximum (latest) years
    where record exists in the database for a given KPI
    Use case: grouped bar chart to compare annual growths across KPIs
    """
    hist = supabase.table("KpiHistory").select("PeriodYear").eq("KpiId", 
                                                  str(kpi_id)).execute()
    
    return sorted(list(pd.DataFrame(hist.data)["PeriodYear"].unique()))


def current_growth_rate(kpi_id):
    """
    Return the annual/current growth rate of the specified KPI
    Utility function

    Growth rate is defined as (current - previous) / previous * 100;

    the current value is the most recent entry in the history table, and the
    previous value is the value preceding the current value

    """

    history = get_pandas_history(kpi_id, ascending=False).dropna().reset_index(drop=True)

    current_val = history.loc[0]["Value"]
    previous_val = history.loc[1]["Value"]

    avg_growth = (current_val - previous_val) / previous_val * 100

    return current_val, avg_growth


def key_stats(kpi_id):
    """
    Return the current value and the growth rate of the specified KPI
    Use case: stats (number) box
    """

    return current_growth_rate(kpi_id)


def annual_average_growth(kpi_id, years=[2022, 2023]):
    ### Not applicable unless we use synthetic data ###
    """
    Return annual (average) growth for a given KPI for the years given
    Use case: grouped bar chart

    the current and previous values are the annual averages of the current 
    and the preceding years
    """

    history = get_pandas_history(kpi_id, ascending=False
                                 ).dropna().reset_index(drop=True)
    all_years = get_years(kpi_id)

    previous_year = all_years[all_years.index(years[0])-1]
    previous_val = history.loc[history["PeriodYear"] == 
                                   previous_year]["Value"].mean()

    growth = []
    for year in years:
        current_year = year
        current_val = history.loc[history["PeriodYear"] == 
                                  current_year]["Value"].mean()
        growth.append((current_val - previous_val) / previous_val * 100)
        previous_year = current_year
        previous_val = current_val

    return growth
