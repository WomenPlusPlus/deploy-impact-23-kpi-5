import { createClient } from "@supabase/supabase-js";

const supabaseUrl = "https://chwdzfycyxvorphbdwcx.supabase.co";
const supabaseKey =
  "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNod2R6ZnljeXh2b3JwaGJkd2N4Iiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTYzNTY0MzIsImV4cCI6MjAxMTkzMjQzMn0.GgST5c8907Dduzc8ieQqJjRXTChCTHxGUVfhXWrngFE";

export const supabase = createClient(supabaseUrl, supabaseKey);
