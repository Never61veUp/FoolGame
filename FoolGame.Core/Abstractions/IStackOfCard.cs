namespace FoolGame.Core.Model;

public interface IStackOfCard
{
    void InitializeDeck();
    List<Card> PopCards(int count);
    Card GetCard();
    bool HasCards();
    int RemainingCardsCount();
}