namespace BlazorFastRollingNumbers.Demo.Pages;

public partial class Home
{
    private int _playgroundValue = 123456;
    private int _counter;
    private int _score = 12345;
    private int _temp = -5;
    private int _price = 99900;
    private int _subscribers = 42567;
    private int _likes = 8934;
    private int _views = 156789;

    private void RandomPlayground()
    {
        _playgroundValue = System.Random.Shared.Next(-999999, 999999);
    }
}

