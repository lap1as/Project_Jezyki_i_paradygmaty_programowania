open System
open System.Linq

// Funkcja licząca liczbę słów
let countWords (text: string) : int =
    text.Split([|' '; '\n'; '\r'; '.'; ','; ';'; ':'|], StringSplitOptions.RemoveEmptyEntries).Length

// Funkcja licząca liczbę znaków (bez spacji)
let countChars (text: string) : int =
    text.Replace(" ", "").Length

// Funkcja znajdująca najczęściej występujące słowo
let mostFrequentWord (text: string) : string =
    let words = text.Split([|' '; '\n'; '\r'; '.'; ','; ';'; ':'|], StringSplitOptions.RemoveEmptyEntries)
    words
    |> Seq.groupBy id
    |> Seq.map (fun (word, group) -> word, Seq.length group)
    |> Seq.maxBy snd
    |> fst

// Funkcja do komunikacji z użytkownikiem
let getTextData () : string =
    Console.WriteLine("Podaj tekst do analizy:")
    Console.ReadLine()

// Główna logika programu
let main () =
    let text = getTextData()
    
    let wordCount = countWords text
    let charCount = countChars text
    let frequentWord = mostFrequentWord text
    
    printfn "Liczba słów: %d" wordCount
    printfn "Liczba znaków (bez spacji): %d" charCount
    printfn "Najczęściej występujące słowo: %s" frequentWord

main ()
