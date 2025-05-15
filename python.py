import pdfplumber
import csv

with pdfplumber.open("document.pdf") as pdf:
    page = pdf.pages[0]
    table = page.extract_table()
    with open("output.csv", "w", newline="") as f:
        writer = csv.writer(f)
        writer.writerows(table)
