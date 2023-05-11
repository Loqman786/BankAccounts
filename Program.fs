open System

type Account(accountNumber: string, initialBalance: float) = //balance can change as it is a float
    let mutable balance = initialBalance //balance can change

    member this.AccountNumber = accountNumber
    member this.Balance = balance

    
    //This shows what accounts that will be displayed 
    static member accounts = 
        [ Account("22132753", 100.0) //the account budgets 
          Account("22134657", 0.0)
          Account("22186754", 51.0)
          Account("22196853", 5.0)
          Account("22112580", 200.0)
          Account("22157843", 500.0) ] 
    
    
    //Deposit Function 
    member this.Deposit(x: float) = //data type
        balance <- balance + x //passing data into balance 
        printfn "Successfully deposited %.2f. New balance: %.2f" x balance
        // system will write that the deposit is successfully depositied and show u a new balance.
                           
     
     //withdraw function   //data type
    member this.Withdraw(x: float) = //account balance is a float as it changes
        if x <= balance then 
            balance <- balance - x 
            printfn "Successfully Withdrawn %.2f. New balance: %.2f" x balance //shows how much money is withdrawn and what the new balance is
        else
            printfn "Insufficient funds"
            // if balance is lower than withdraw amount display insuffient balance


    member this.CheckBalance () = //Checking function
        printfn "Your balance is: %.2f" balance 
        //displays what your balance is for the account that was chosen

    
    member this.CheckAccount () = //Checkout function 
        match this.Balance with // if it matches any of of the output then please output.
        | balance when balance < 10.0 -> printfn "Balance is low" //system displays balance is low
        | balance when balance > 10.0 && balance <= 100.0 -> printfn "Balance is OK"
        | _ -> printfn "Balance is high" //system displays balance is high

//displays a menu with options
let printMenu () =
    printfn "1. Deposit" 
    printfn "2. Withdraw"
    printfn "3. Check balance"
    printfn "4. Exit"
    printfn "Enter your choice: "

// prints out the account information
let printAccounts () = 
    printfn "Accounts"
    Account.accounts
    |> List.iteri (fun i account ->
        printfn "%d. Account %s, Balance %.2f" (i + 1) account.AccountNumber account.Balance)
    printfn ""

let getInput () = Console.ReadLine() |> int

// F# loop 
let rec menu (account: Account) accountNumber = 
    printfn "Account %s" accountNumber 
    printMenu()
    match getInput() with //checks input
    | 1 -> 
        printfn "Enter amount to deposit:"
        let depositAmount = Console.ReadLine() |> float
        account.Deposit(depositAmount)
        menu(account) accountNumber

    | 2 -> 
        printfn "Enter amount to withdraw:"
        let withdrawAmount = Console.ReadLine() |> float
        account.Withdraw(withdrawAmount)
        menu(account) accountNumber

    | 3 -> 
        account.CheckBalance()
        account.CheckAccount()
        menu(account) accountNumber

    | 4 -> 
        exit 0
    |  _ -> 
        printfn "Invalid choice, please try again"
        menu(account) accountNumber
        // if choice is not between 1-4, this messege will appear


 //recursion, f# looping, select account fucntion
let rec selectAccount () = 
    printAccounts()
    printfn "Select an account (1-6):" // choose an account between 1-6
    let accountNumber = System.Console.ReadLine()
    let index = int accountNumber - 1
    if index >= 0 && index < Account.accounts .Length then
        let account = Account.accounts .[index]
        menu account accountNumber
    else
        printfn "Invalid account number" //if account chosen is not between 1-6 this messege will display
        selectAccount()

selectAccount()
