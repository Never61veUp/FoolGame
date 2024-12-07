using FoolGame.Core.Model;

namespace FoolGame.Core.Abstractions;

public interface ICardCoveringService
{
    void CoverCard(Card cardInHand, Card cardOnDesk, Stack<Card> stack);
}