using FoolGame.Core.Abstractions;

namespace FoolGame.Core.Model;

public class Desk : IDeskCardCoverer, IDeskCardManager
{
    private readonly ICardCoveringService _cardCoveringService;
    private readonly List<Stack<Card>> _cardStacks = [];

    public Desk(ICardCoveringService cardCoveringService)
    {
        _cardCoveringService = cardCoveringService;
    }

    public List<Card> PopAllCardsFromDesk()
    {
        var cardList = new List<Card>();
        foreach (var card in _cardStacks)
        {
            if (card.Count > 0)
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
            _cardCoveringService.CoverCard(cardInHand, cardOnDesk, stack);
        }
    }
}