namespace FoolGame.Core.Model;

public interface IDeskCardManager
{
    List<Card> PopAllCardsFromDesk();
    void AddNewCard(Card card);
}