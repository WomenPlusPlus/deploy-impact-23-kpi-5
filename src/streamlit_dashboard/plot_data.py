from utils import *
import numpy as np


def generate_xlabel(years, months):
    month_dict = {1: "Jan", 2: "Feb", 3: "Mar", 4: "Apr", 5: "Mai", 6: "Jun", 
                  7: "Jul", 8: "Aug", 9: "Sep", 10: "Okt", 11: "Nov", 12: "Dez"}
    
    return [str(month_dict[month]) + str(year)[-2:] for month, year in zip(months, years)]


def invert_xlabel(label):
    month_dict = {"Jan": 1, "Feb": 2, "Mar": 3, "Apr": 4, "Mai": 5, "Jun": 6, 
                  "Jul": 7, "Aug": 8, "Sep": 9, "Okt": 10, "Nov": 11, "Dez": 12}
    
    month = label[:3]
    year = label[-2:]

    return (int("20"+year), month_dict[month])
    


def generate_linechart(kpi_id, timefrom, timeto, alltime=False):
    history = get_pandas_history(kpi_id)
    xs = generate_xlabel(history["PeriodYear"], history["PeriodMonth"])
    history["Time"] = xs

    if alltime:
        return history
    
    # apply time filters
    history = history.loc[(history["PeriodYear"] >= timefrom[0])
                & (history["PeriodYear"] <= timeto[0])]
    years = list(history["PeriodYear"].unique())
    year_from, year_to = min(years), max(years)
    years.remove(year_from)
    if year_from != year_to:
        years.remove(year_to)
    df1 = history.loc[(history["PeriodYear"] == year_from)
                & (history["PeriodMonth"] >= timefrom[1])]
    df2 = history.loc[(history["PeriodYear"] == year_to)
                & (history["PeriodMonth"] <= timeto[1])]
    df3 = history.loc[history["PeriodYear"].isin(years)]

    df = pd.concat([df1, df2, df3]).sort_values(["PeriodYear", "PeriodMonth"], 
                        ascending=True, ignore_index=True)


    # ind_st = history.index[(history["PeriodYear"] == timefrom[0])
    #                     & (history["PeriodMonth"] == timefrom[1])][0]
    # ind_end = history.index[(history["PeriodYear"] == timeto[0])
    #                     & (history["PeriodMonth"] == timeto[1])][0]

    # df = history[(history.index >= ind_st) & (history.index <= ind_end)]

    xs = generate_xlabel(df["PeriodYear"], df["PeriodMonth"])
    df["Time"] = xs

    return df


def generate_barchart(kpis):
    """
    Return current growth of all KPIs in the circle
    Use case: bar chart

    Parameter: kpis: list of dictionaries returned by user_choice
    """

    curr_growth, names = [], []

    for kpi in kpis:
        names.append(kpi["Name"])
        _, curr_gr = current_growth_rate(kpi["id"])
        curr_growth.append(curr_gr)
    
    return pd.DataFrame({"KPI": names, "growth rate": curr_growth})
    

def generate_groupedbarchart(kpis):

    yearslist = []
    for kpi in kpis:
        yearslist.append(set(get_years(kpi["id"])))
    # to take into account the possibility of different KPIs having
    # different years in record - only take the years where all
    # historical record of KPIs exist
    common_years = set.intersection(*yearslist)
    possible_years = np.arange(min(common_years)+1, max(common_years)+1)
    
    name, annual_growth = [], []
    year = [str(y) for y in possible_years] * len(kpis)
    for kpi in kpis:
        growth = annual_average_growth(
                    kpi["id"], years= possible_years)
        name.extend([kpi["Name"]] * len(growth))
        annual_growth.extend(growth)
    
    df = pd.DataFrame(name, columns=["KPI"])
    df["annual growth"] = annual_growth
    df["year"] = year

    return df
