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
