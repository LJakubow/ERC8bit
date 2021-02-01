using System;
using System.Collections.Generic;

namespace naukaKonsoli
{

	class Program
	{

		static void Main(string[] args)
		{
			// pobranie nazwy katalogu głównego rozwiazania i pobranie danych z pliku input
			string directory = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
			string text = System.IO.File.ReadAllText(@directory + "/" + "input.txt");
			// stworzenie tablicy elementów i podział wcześniej pobranych danych w 8 znakowe elementy
			int zmienna2 = text.Length;
			string[] tablica = new string[zmienna2 / 8];
			int j = 0;
			for (int i = 0; i < zmienna2; i += 8)
			{
				tablica[j] = text.Substring(i, Math.Min(8, text.Length - i));
				j++;
			}
			var zmienna3 = tablica.Length;
			var iloscbledow = 0;
			// stworzenie listy dynamicznej i sprawdzenie warunków z zadania, zwiekszając iloscbledow jako ilosc elementów błędnych
			List<string> tablica2 = new List<string>();
			for (j = 0; j < tablica.Length; j++)
			{
				string dane = tablica[j];
				int liczba = Convert.ToInt32(tablica[j].Substring(0, 4), 2);
				bool kontrolka = Convert.ToBoolean(Convert.ToInt32(tablica[j].Substring(7, 1)));
				bool ifparzysta;
				string wiadomosc = tablica[j].Substring(4, 3);
				string zlawiadomosc = "000";
				if (liczba % 2 == 0)
				{
					ifparzysta = true;
				}
				else
				{
					ifparzysta = false;
				}
				if (ifparzysta == kontrolka && wiadomosc != zlawiadomosc)
				{
					tablica2.Add(dane);
				}
				else iloscbledow++;
			}
			// plik output.txt znajduje się w tym samym katalogu co input.txt
			System.IO.File.WriteAllText(@directory + "/" + "output.txt", zmienna3 + "\n" + iloscbledow + "\n" + String.Join(", ", tablica2));
		}
	}
}

