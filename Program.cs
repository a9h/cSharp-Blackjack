

class Hand
{
    private int cardOne;

    private int cardTwo;

    private int cardThree;

    private int cardFour;

    private int cardFive;

    private int counter;

    private bool dealer;

    private bool stand;

    private int total;

    private bool hasAce;


    public Hand(bool dealerTrue)
    {
        Random rng = new Random();

        cardOne = rng.Next(1, 12);
        cardTwo = rng.Next(1, 12);
        cardThree = rng.Next(1, 12);
        cardFour = rng.Next(1, 12);
        cardFive = rng.Next(1, 12);

        hasAce = false;




        counter = 0;

        total = cardOne + cardTwo;

        stand = false;





        dealer = dealerTrue;



    }

    private int CalculateTotal()
    {
        int total = 0;
        int numberOfAces = 0;

        // List to hold the cards that have been drawn
        List<int> cardsInHand = new List<int>();

        // Add the initial two cards
        cardsInHand.Add(cardOne);
        cardsInHand.Add(cardTwo);

        // Add additional cards based on the counter
        if (counter >= 1) cardsInHand.Add(cardThree);
        if (counter >= 2) cardsInHand.Add(cardFour);
        if (counter >= 3) cardsInHand.Add(cardFive);

        foreach (int card in cardsInHand)
        {
            int cardValue = card;

            if (cardValue == 1)
            {
                cardValue = 11; // Initially treat Ace as 11
                numberOfAces++;
            }
            else if (cardValue == 11)
            {
                cardValue = 10; // Face cards (Jack, Queen, King)
            }
            // Else, cardValue remains as is (2-10)

            total += cardValue;
        }

        // Adjust for Aces if total is over 21
        while (total > 21 && numberOfAces > 0)
        {
            total -= 10; // Count one Ace as 1 instead of 11
            numberOfAces--;
        }

        return total;
    }






    public void dealerDraw()
    {
        Console.WriteLine($"Dealer has {this.cardOne}, {this.cardTwo}");

        int total;
        total = this.cardOne + this.cardTwo;



        while (total <= 17)
        {

            Console.WriteLine("Dealer has less than 17, hitting");
            this.counter++;

            switch (counter)
            {
                case 1:
                    total = this.cardOne + this.cardTwo + this.cardThree;

                    break;
                case 2:
                    total = total = this.cardOne + this.cardTwo + this.cardThree + this.cardFour;
                    break;
                case 3:
                    total = total = this.cardOne + this.cardTwo + this.cardThree + this.cardFive + this.cardFour;
                    break;
                default:
                    break;




            }
            Console.WriteLine($"The dealer has {total}");






        }
        Console.Clear();

        if (total > 21)
        {
            Console.WriteLine("Dealer went bust! You win!");

        }

        Console.WriteLine($"The dealer has {total}, standing!");
















    }






    public void HitOrStand()
    {
        int card;

        card = 0;

        if (this.dealer == true)
        {



            this.total = this.cardOne + this.cardTwo;

            Console.WriteLine($"Dealer has {this.cardOne}, {this.cardTwo}, hitting!");

            while (this.total < 17)
            {


                this.counter++;
                Console.ReadKey();

                switch (this.counter)
                {
                    case 1:


                        this.total = this.cardOne + this.cardTwo + this.cardThree;
                        card = this.cardThree;

                        break;
                    case 2:
                        this.total = this.cardOne + this.cardTwo + this.cardThree + this.cardFour;
                        card = this.cardFour;
                        break;
                    case 3:
                        this.total = this.cardOne + this.cardTwo + this.cardThree + this.cardFive + this.cardFour;
                        card = this.cardFive;
                        break;
                    default:
                        break;





                }
                Console.ReadKey();
                if (this.total > 21)
                {
                    Console.Write($"The dealer drew  a {card} and went bust!");

                    Console.ReadKey();
                    break;
                }
                else if (this.total == 21)
                {
                    Console.WriteLine($"The dealer drew a {card} and made 21! You loose.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"Dealer drew a {card}, the total is {this.total}");
                }







            }





            Console.WriteLine($"The dealer has {this.total} (more than 17), standing!");
            Console.ReadKey();



        }
        else
        {
            while (!this.stand)


            {

                Console.WriteLine("Hit or stand? (H/S)");

                if (Console.ReadLine() == "h")
                {
                    Console.WriteLine("Drawing new card!");

                    this.counter++;

                    switch (this.counter)
                    {
                        case 1:
                            this.total = this.cardOne + this.cardTwo + this.cardThree;
                            Console.WriteLine($"You drew {this.cardThree}::: You now have {this.cardOne}, {this.cardTwo} {this.cardThree} ({this.total})");
                            

                            break;
                        case 2:
                            this.total = this.cardOne + this.cardTwo + this.cardThree + this.cardFour;
                            Console.WriteLine($"You drew a {this.cardFour}:::You now have {this.cardOne}, {this.cardTwo}, {this.cardThree}, {this.cardFour} ({this.total})");
                            
                            break;
                        case 3:
                            this.total = this.cardOne + this.cardTwo + this.cardThree + this.cardFive + this.cardFour;
                            Console.WriteLine($"You drew {this.cardFive}::: You now have {this.cardOne}{this.cardTwo}{this.cardThree}, {this.cardFour}, {this.cardFive} ({this.total})");

                            
                            break;
                        default:
                            break;

                    }




                    if(this.total > 21)
                    {
                        Console.WriteLine("You went BUSST!");
                        break;
                    }
                    else if (this.total == 21)
                    {
                        break;
                    }

                }
                else
                {
                    this.stand = true;



                    Console.WriteLine($"Standing! Your total is {this.total}");

                    
















                }




            }
        }
    }






    public void outputHand()
    {


        if (this.dealer == true)
        {
            Console.WriteLine($"Dealer has {this.cardOne}");

        }
        else
        {

            Console.WriteLine($"You have {this.cardOne} and {this.cardTwo}");

        }


    }


    public int CardOne
    {
        get { return this.cardOne; }
        set { this.cardOne = value; }
    }
    public int CardTwo
    {
        get { return this.cardTwo; }
        set { this.cardTwo = value; }
    }
    public int CardThree
    {
        get { return this.cardThree; }
        set { this.cardThree = value; }
    }
    public int CardFour
    {
        get { return this.cardFour; }
        set { this.cardFour = value; }
    }
    public int CardFive
    {
        get { return this.cardFive; }
        set { this.cardFive = value; }
    }
    public int Counter
    {
        get { return this.counter; }
        set { this.counter = value; }
    }
    public int Total
    {
        get { return this.total; }
        set { this.total = value; }
    }
    public bool Stand
    {
        get { return this.stand; }
        set { this.stand = value; }
    }





}









class Program
{

    static bool CheckWin(Hand dealer, Hand player)
    {
        if (dealer.Total > player.Total)
        {
            return false;

        }
        else
        {
            return true;
        }
    }



    static void Main(string[] args)
    {
        

        Hand dealer = new Hand(true);
        Hand player = new Hand(false);

        dealer.outputHand();

        player.outputHand();

        player.HitOrStand();

        dealer.HitOrStand();


        if (CheckWin(dealer, player) == false)
        {
            Console.WriteLine($"You have {player.Total} and dealer has Dealer wins!");
        }
        else
        {
            Console.WriteLine("Player wins");
        }






    }
}
