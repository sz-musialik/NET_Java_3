# Laboratorium 3 - Obliczenia wielowątkowe w technologii .NET
Aplikacji konsolowa porównuje wydajność mnożenia macierzy kwadratowych o zadanych wymiarach w zależności od ilości wątków i rodzaju implementacji.

Aplikacja okienkowa realizuje wielowątkowe przetwarzanie obrazu.

## Mnożenie macierzy
Generowane są macierze o zadanym rozmiarze, które są losowo wypełniane przy pomocy metody `FillRandom()`

Macierze są wymnażane w sposób:
- Sekwencyjny,
- Z wykorzystaniem biblioteki `Paralell`,
- Z wykorzystaniem klasy `Thread`.

Testowano macierze o rozmiarach `{ 100, 250, 500 }` oraz podział zadań na `{ 2, 4, 8, 12, 16, 20 }` wątków.

Wyniki wypisywane w konsoli są średnimi z pięciu pomiarów. Dla laptopa o `4` rdzeniach i `8` procesach logicznych otrzymano następujące wyniki:

### Rozmiar 100
| Sekwencyjnie (ms)  | Wątki  | Parallel (ms)  | Thread (ms)  |
|---|---|---|---|
| 14  | 2  | 5  | 6  |
| 10  | 4  | 3  | 5  |
| 10  | 8  | 3  | 5  |
| 11  | 12  | 3  | 4  |
| 10  | 16  | 3  | 5  |
| 10  | 20  | 3  | 4  |

### Rozmiar 250
| Sekwencyjnie (ms)  | Wątki  | Parallel (ms)  | Thread (ms)  |
|---|---|---|---|
| 181  | 2  | 111  | 105  |
| 167  | 4  | 57  | 57  |
| 172  | 8  | 48  | 52  |
| 173  | 12  | 49  | 54  |
| 168  | 16  | 54  | 57  |
| 168  | 20  | 51  | 57  |

### Rozmiar 500
Wartość przyspieszenia uzyskano ze wzorów:

$$\left( 1 - \frac{Parallel}{Sekwencyjnie}\right) \cdot 100 \\%$$
oraz $$\left( 1 - \frac{Thread}{Sekwencyjnie}\right) \cdot 100 \\%$$.

| Sekwencyjnie (ms)  | Wątki  | Parallel (ms)  | Thread (ms)  | Przyspieszenie Paralell  | Przyspieszenie Thread  |
|---|---|---|---|---|---|
| 1351  | 2  | 730  | 787  | 45,97%  | 41,75%  |
| 1371  | 4  | 436  | 467  | 68,20%  | 65,94%  |
| 1443  | 8  | 505  | 540  | 65,00%  | 62,58%  |
| 1458  | 12  | 502  | 584  | 65,57%  | 59,95%  |
| 1423  | 16  | 495  | 536  | 65,21%  | 62,33%  |
| 1425  | 20  | 498  | 529  | 65,05%  | 62,88%  |

Przyspieszenie wymnażania macierzy najprościej było odczytać przy rozmiarze macierzy wynoszącym 500. Największe względne przyspieszenie uzyskano przy zwiększeniu ilości wątków z 1 do 2 - dla biblioteki `Paralell` 45,97%, a dla klasy `Thread` 41,75%. 

Największe przyspieszenie bezwzględne uzyskano dla 4, co pokrywa się z ilością rdzeni fizycznych procesora urządzenia. Dla biblioteki `Paralell` uzyskano 68,20% przyspieszenie względem sekwencyjnego wymnażania macierzy, a dla klasy `Thread` uzyskano 65,94% przyspieszenie.

Po przekroczeniu ilości rdzeni fizycznych procesora, operacja wymnażania macierzy nie przekracza przyspieszenia maksymalnego uzyskanego wcześniej.

Implementacja wykorzystująca klasę `Thread` działa wolniej niż ta wykorzystująca bibliotekę `Paralell`.

## Wielowątkowe przetwarzanie obrazu
Aplikacja okienkowa została zaimplementowana za pomocą **Windows Forms**.

Przy pomocy `openFileDialog` użytkownik wybiera obraz, który ma zostać przetworzony.

Na obraz nakładane są efekty:
- Skala szarości,
- Negatyw,
- Progowanie,
- Odbicie lustrzane.

Każdy z efektów wykonuje się na osobnym wątku, co zostało zaimplementowane przy pomocy klasy `Thread`.

<img width="569" height="382" alt="obraz" src="https://github.com/user-attachments/assets/e7fcef62-fbb5-41c7-ae32-35d57a1d0824" />

## Uruchomienie projektu
Aby uruchomić aplikację konsolową do testu wydajności wielowątkowego mnożenia macierzy należy otworzyć projekt w środowisku Visual Studio oraz wybrać podprojekt `MatrixBenchmark` jako projekt startowy.

Aby uruchomić programu z interfejsem graficznym do wielowątkowego przetwarzania obrazów należy wybrać podprojekt `ImageFiltersApp` jako projekt startowy.
