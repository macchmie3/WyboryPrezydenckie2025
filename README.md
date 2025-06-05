Analiza wyników wyborów prezydenckich 2025

Plik Output.xlsx zawiera wykresy i arkusz z danymi każdej komisji - zapraszam do ściągnięcia i sprawdzenia.

# Uwagi wstępne:
- Przedstawione wyniki są z pominięciem komisji, gdzie w pierwszej turze głosowało mniej niż 100 osób, a także: zakłady lecznicze, areszty i zakłady karne
- Konkretne obwody w danych .csv ze strony wybory.gov.pl nie zawierają żadnych wyróżniających się identyfikatorów komisji, jednak na oko wygląda, że są one posortowane dla obu tur tak samo, i takie przyjąłem założenie
- Obliczenia przewidywanych głosów rozważano w kontekście danej komisji wyborczej
  
# Przykład uproszczony dla jednej komisji
Głosy w pierwszej turze: 500
- w tym Trzaskowski 100
- w tym Nawrocki 150
- w tym Mentezn 250

To w drugiej turze przy frekwencji 750: 
- Trzaskowski = 1.5 * (100 + 0.119 * 250)
- Nawrocki = 1.5 * (150 + 0.881 * 250)


# Założenia
- Zakłada się, że wyborcy Trzaskowskiego głosujący na niego w pierwszej turze, głosowali też na niego w drugiej turze
- Zakłada się, że wyborcy Nawrockiego głosujący na niego w pierwszej turze, głosowali też na niego w drugiej turze
- Zakłada się, że wyborcy głosujący w danym okręgu na kandydata innego niż ww. w pierwszej turze, w drugiej turze zagłosowali zgodnie z podziałem z Exit Pollu

# Wyniki gdyby spełniono powyższe założenia:
Nawrocki - 52,29%
Trzaskowski - 47,71%

# Wykresy dla różnicy wyniku właściwych danego kandydata z jego wynikiem przewidywanym w ramach tej formuły
- oś X różnica między wynikiem w drugiej turze, a predykcją
- oś Y liczba komitetów dla danej różnicy

Trzaskowski: 
![Trzaskowski](https://github.com/user-attachments/assets/887ee23a-f1a3-4e70-934e-70fffd9da6ee)

Nawrocki:
![Nawrocki](https://github.com/user-attachments/assets/e71cbc2a-b704-4b3c-9f98-d48814bd3926)

# Parametry statystyczne do danych z powyższych wykresów
| Wskaźnik  | Trzaskowski | Nawrocki |
| ------------- | ------------- | ------------- |
| Średnia arytmetyczna | 21.55  | -9.84 |
| Odchylenie standardowe  | 248.44  | 27.56  |
| Kurtoza  | 6.25  | 21.21  |

# Uwagi końcowe
- Gdyby pominąć totalnie przepływy wyborców, i patrzeć tylko na głosy Trzaskowski / Nawrocki, to rozkład różnic między pierwszą a drugą turą jest rozkładem Gaussa, nie chce mi się go ponownie teraz wyliczać, ale nie faworyzuje Nawrockiego (wręcz jest pro-Trzaskowski)

# Źródła:
- dane o przepływach głosujących z https://polskieradio24.pl/artykul/3531756,jak-zaglosowali-wyborcy-brauna-holowni-i-mentzena-przeplywy-elektoratu-w-ii-turze
- dane z obu tur pobrane z https://wybory.gov.pl/prezydent2025/pl/dane_w_arkuszach
