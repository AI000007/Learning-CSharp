ChestState chestState = ChestState.Locked;

while (true)
{
    Console.Write($"The chest is {chestState}. What do you want to do? ");
    string action = Console.ReadLine();

    switch (chestState)
    {
        case ChestState.Locked:
            if (action == "unlock") chestState = ChestState.Closed;
            break;

        case ChestState.Closed:
            if (action == "lock") chestState = ChestState.Locked;
            else if (action == "open") chestState = ChestState.Open;
            break;

        case ChestState.Open:
            if (action == "close") chestState = ChestState.Closed;
            break;
    }

}

enum ChestState { Open, Closed, Locked };
