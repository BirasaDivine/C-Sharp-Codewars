using System;

namespace ExpenseTrackerApp
{
    // Tasks 1, 2 and 8 code here.
    [Flags] enum ExpenseType{
      None=0,
      Travel=1,
      Meals=2,
      OfficeSupplies=4,
      Software=8,
      Entertainment=16
    }

    // Task 8
    enum ApprovalStage
    {
      Draft = 0,
      Submitted = 1,
      UnderReview = 2,
      Approved = 3,
      Rejected = 4
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Expense Tracker App Running...");

            // Task 3-7, 9-16 code here.
            foreach (string elements in Enum.GetNames(typeof(ExpenseType))){
              Console.WriteLine($"{elements}");
            }
            ExpenseType expenses= ExpenseType.Travel | ExpenseType.Meals ; 
            if ((expenses & ExpenseType.Meals)== ExpenseType.Meals ){
                Console.WriteLine($"Expense includes:{ExpenseType.Meals}");
              } else{
                Console.WriteLine("Expense does not include Meals");
                }
                expenses &= ~ExpenseType.Meals;
                Console.WriteLine(expenses);

                if (Enum.TryParse("Meals, Software" , out ExpenseType parsedExpense))
                {
                  Console.WriteLine("Success Message");
                }
                else
                {
                  Console.WriteLine("Error Message");
                }

            // Task 9
            foreach (ApprovalStage stage in Enum.GetValues(typeof(ApprovalStage)))
            {
                Console.WriteLine($"{stage} = {(int)stage}");
            }

            // Task 10
            if (Enum.TryParse("Submitted", out ApprovalStage parsedStage))
            {
                Console.WriteLine($"Parsed stage: {parsedStage}");
            }
            else
            {
                Console.WriteLine("Error: could not parse approval stage.");
            }

            // Task 11
            int approvalValue = 4;
            if (Enum.IsDefined(typeof(ApprovalStage), approvalValue))
            {
                ApprovalStage definedStage = (ApprovalStage)approvalValue;
                Console.WriteLine($"Value {approvalValue} corresponds to: {definedStage}");
            }
            else
            {
                Console.WriteLine($"Value {approvalValue} is not defined in ApprovalStage.");
            }

            // Task 12
            ApprovalStage currentStage = ApprovalStage.UnderReview;
            switch (currentStage)
            {
                case ApprovalStage.Draft:
                    Console.WriteLine("This expense is still a draft.");
                    break;
                case ApprovalStage.Submitted:
                    Console.WriteLine("This expense has been submitted.");
                    break;
                case ApprovalStage.UnderReview:
                    Console.WriteLine("This expense is currently under review.");
                    break;
                case ApprovalStage.Approved:
                    Console.WriteLine("This expense has been approved.");
                    break;
                case ApprovalStage.Rejected:
                    Console.WriteLine("This expense has been rejected.");
                    break;
                default:
                    Console.WriteLine("Unknown approval stage.");
                    break;
            }

            // Task 13
            ExpenseType validExpense = ExpenseType.OfficeSupplies | ExpenseType.Software;

            // Task 14
            if (Enum.IsDefined(typeof(ExpenseType), "Meals"))
            {
                Console.WriteLine("'Meals' is a valid ExpenseType.");
            }
            else
            {
                Console.WriteLine("'Meals' is not a valid ExpenseType.");
            }

            // Task 15
            currentStage = ApprovalStage.Approved;
            Console.WriteLine($"Valid expense: {validExpense}");
            Console.WriteLine($"Current stage: {currentStage}");
        }
    }
}