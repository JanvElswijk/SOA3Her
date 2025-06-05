public class Forum
{
    private List<Thread> threads;
}


// Het kan zijn dat er onduidelijkheid is over een backlog item. Dan kan men daarover discussiëren door
// naar elkaar toe te stappen of, indien developers niet fysiek bij elkaar zitten, te Skypen/mailen etc.
// Uiteindelijk worden resultaten van deze discussies in het forum van de applicatie gezet. Daar kunnen
// verschillende discussies met diverse onderwerpen gestart worden of men kan reacties toevoegen. Er
// kunnen dus diverse discussiethreads ontstaan, zoals je op diverse fora ziet. 

// Elke thread is gerelateerd aan een backlog item. Zodra het backlog item, waar de discussie betrekking op heeft, afgerond is,
// kan niets meer worden gewijzigd in de discussie(onderdelen) en kunnen er geen nieuwe berichten
// aan die threads worden toegevoegd of nieuwe threads worden gemaakt. Let erop dat een backlog
// item in de kolom ‘done’ kan worden geplaatst, maar daar ook weer terug naar ‘todo’ kan, mogelijk
// gepaard mét of naar aanleiding van een discussie. Dus waarschijnlijk is die status niet voldoende… Bij
// reacties in de discussie krijgen teamleden een bericht.