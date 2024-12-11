open System

// Definicja stałych kursów walutowych
let exchangeRates = 
    [ "USD", 1.0; "EUR", 0.94; "GBP", 0.82; "PLN", 4.56 ]

// Funkcja przeliczająca waluty
let convertCurrency amount fromCurrency toCurrency =
    let fromRate = List.tryFind (fun (currency, _) -> currency = fromCurrency) exchangeRates
    let toRate = List.tryFind (fun (currency, _) -> currency = toCurrency) exchangeRates

    match fromRate, toRate with
    | Some (_, fromRateValue), Some (_, toRateValue) -> 
        (amount * toRateValue) / fromRateValue
    | _ -> failwith "Nieznany kurs waluty"

// Funkcja do komunikacji z użytkownikiem
let getCurrencyData () =
    Console.Write("Podaj kwotę do przeliczenia: ")
    let amount = Convert.ToDouble(Console.ReadLine())

    Console.Write("Podaj walutę źródłową: ")
    let fromCurrency = Console.ReadLine().ToUpper()

    Console.Write("Podaj walutę docelową: ")
    let toCurrency = Console.ReadLine().ToUpper()

    amount, fromCurrency, toCurrency

// Główna logika programu
let main () =
    let amount, fromCurrency, toCurrency = getCurrencyData()
    try
        let result = convertCurrency amount fromCurrency toCurrency
        printfn "Kwota %.2f %s przeliczona na %s wynosi %.2f" amount fromCurrency toCurrency result
    with
    | ex -> printfn "Błąd: %s" ex.Message

main ()
