from dotenv import load_dotenv
import os
from supabase import Client

load_dotenv()
url = os.environ.get("SUPABASE_URL")
key = os.environ.get("SUPABASE_KEY")


supabase = Client(url, key)
