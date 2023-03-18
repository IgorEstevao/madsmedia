﻿namespace Videos.Api.Dtos;

public class Response<T>
{
    public bool Success { get; }
    public T Data { get; }

    public Response(T data)
    {
        Success = true;
        Data = data;
    }
}
