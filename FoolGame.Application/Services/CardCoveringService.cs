using FoolGame.Core.Abstractions;
using FoolGame.Core.Model;

namespace FoolGame.Application.Services;

public class CardCoveringService : ICardCoveringService
{
    public void CoverCard(Card cardInHand, Card cardOnDesk, Stack<Card> stack)
    {
        if (stack.Count == 1)
        {
            var card = stack.Peek();
            if (card.CompareTo(cardOnDesk) == 0 && cardInHand.CompareTo(cardOnDesk) == 1)
            {
                stack.Push(cardInHand);
            }
        }
    }
}