using System;
using MediatR;

namespace Videos.Api.Domain.Events;

public class Event : INotification
{
	public DateTime Timestamp { get; }

	protected Event()
	{
		Timestamp = DateTime.UtcNow;
	}
}