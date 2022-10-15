namespace Api.Services;

public interface ISmsService {
  Task Send(int number, string message);
}