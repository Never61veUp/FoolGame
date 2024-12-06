namespace FoolGame.Core.Model;

public class Desk
{
    private List<Stack<Card>> _cardStacks;

    public Desk()
    {
        _cardStacks = new List<Stack<Card>>();
    }

    public List<Card> PopAllCardsFromDesk()
    {
        var cardList = new List<Card>();
        foreach (var card in _cardStacks)
        {
            cardList.Add(card.Pop());
        }
        _cardStacks.Clear();
        return cardList;
    }
    
    public void AddNewCard(Card card)
    {
        var newStack = new Stack<Card>();
        newStack.Push(card);
        
        _cardStacks.Add(newStack);
    }

    public void CoverCard(Card cardInHand, Card cardOnDesk)
    {
        foreach (var stack in _cardStacks)
        {
            if (stack.Count == 1)
            {
                var card = stack.Peek();
                if (card.CompareTo(cardOnDesk) == 0)
                {
                    if (cardInHand.CompareTo(cardOnDesk) == 1)
                    {
                        stack.Push(cardInHand);
                    }
                }
                
            }
            
        }
    }
    
    
}