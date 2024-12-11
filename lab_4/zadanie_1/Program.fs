open System

// Definicja rekordu dla danych użytkownika
type Uzytkownik = { waga: float; wzrost: float }

let obliczBMI (waga: float) (wzrost: float) =
    let wzrostMetry = wzrost / 100.0
    waga / (wzrostMetry * wzrostMetry)

let kategoriaBMI (bmi: float) =
    match bmi with
    | _ when bmi < 16.0 -> "Wygłodzenie"
    | _ when bmi < 16.9 -> "Wychudzenie"
    | _ when bmi < 18.5 -> "Niedowaga"
    | _ when bmi < 24.9 -> "Prawidłowa masa ciała"
    | _ when bmi < 29.9 -> "Nadwaga"
    | _ when bmi < 34.9 -> "Otyłość I stopnia"
    | _ when bmi < 39.9 -> "Otyłość II stopnia"
    | _ -> "Otyłość III stopnia"

let main () =
    Console.WriteLine("Podaj wagę (kg):")
    let waga = Console.ReadLine() |> float
    Console.WriteLine("Podaj wzrost (cm):")
    let wzrost = Console.ReadLine() |> float
    
    let bmi = obliczBMI waga wzrost
    let kategoria = kategoriaBMI bmi

    printfn "Twoje BMI wynosi: %.2f" bmi
    printfn "Kategoria BMI: %s" kategoria

main ()
