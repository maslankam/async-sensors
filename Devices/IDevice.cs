namespace dependencyInAction{
    public interface IDevice
    {
        Status getStatus();
        int getId();

    }

    public enum Status {busy, idle, error}
}