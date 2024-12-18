open System

type Tree<'T> =
    | Empty
    | Node of 'T * Tree<'T> * Tree<'T>

let rec fibonacci n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fibonacci (n - 1) + fibonacci (n - 2)

let fibonacciTailRec n =
    let rec aux a b n =
        match n with
        | 0 -> a
        | _ -> aux b (a + b) (n - 1)
    aux 0 1 n

let rec findElement tree value =
    match tree with
    | Empty -> false
    | Node (v, left, right) -> 
        if v = value then true
        elif value < v then findElement left value
        else findElement right value

let rec permute lst =
    match lst with
    | [] -> [[]]
    | x :: xs -> 
        let perms = permute xs
        [ for perm in perms do
            for i in 0..List.length perm do
                yield List.insertAt i x perm ]

let rec hanoi n source target auxiliary =
    if n = 1 then
        printfn "Move disk from %s to %s" source target
    else
        hanoi (n - 1) source auxiliary target
        printfn "Move disk from %s to %s" source target
        hanoi (n - 1) auxiliary target source

let rec quickSort lst =
    match lst with
    | [] -> []
    | pivot :: tail -> 
        let less = List.filter (fun x -> x < pivot) tail
        let greater = List.filter (fun x -> x >= pivot) tail
        quickSort less @ [pivot] @ quickSort greater

[<EntryPoint>]
let main argv =
    let rec promptUser () =
        printfn "Choose a task to run:"
        printfn "1. Fibonacci Recursive"
        printfn "2. Fibonacci Tail Recursive"
        printfn "3. Find Element in Binary Tree"
        printfn "4. Generate Permutations"
        printfn "5. Solve Towers of Hanoi"
        printfn "6. QuickSort"
        printfn "7. Exit"
        let input = Console.ReadLine()
        match input with
        | "1" -> 
            printfn "Fibonacci (Recursive) for n=5: %d" (fibonacci 5)
            promptUser ()
        | "2" -> 
            printfn "Fibonacci (Tail Recursive) for n=5: %d" (fibonacciTailRec 5)
            promptUser ()
        | "3" -> 
            let tree = Node(10, Node(5, Empty, Empty), Node(15, Empty, Empty))
            let value = 5
            printfn "Element %d found: %b" value (findElement tree value)
            promptUser ()
        | "4" -> 
            let list = [1; 2; 3]
            let perms = permute list
            printfn "Permutations of %A: %A" list perms
            promptUser ()
        | "5" -> 
            hanoi 3 "A" "C" "B"
            promptUser ()
        | "6" -> 
            let list = [3; 1; 4; 1; 5; 9; 2]
            let sortedList = quickSort list
            printfn "Sorted list: %A" sortedList
            promptUser ()
        | "7" -> 
            printfn "Exiting program."
            0
        | _ -> 
            printfn "Invalid choice, please choose a number between 1 and 7."
            promptUser ()
    
    promptUser ()
