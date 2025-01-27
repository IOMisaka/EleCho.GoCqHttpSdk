---
layout: post
title:  "4. 学习如何执行操作: 发送消息, 群组踢人"
date:   2023-02-13 17:18:00 +0800
categories: tutorial
---

在 Go-CqHttp 中，一个个的 API 被称作 ”Action“，也可以叫做 ”操作“




## 创建操作

在第二节中我们已经做了最基本的 Action 调用，里面创建了一个 CqSendPrivateMessageAction.

创建一个操作当然很简单，直接 new 一个对象即可。EleCho.GoCqHttpSdk 为所有支持的 Action 都抽象成了对应的类，你只需要创建他们即可使用，所有的参数都在构造函数或类型成员中，使用起来非常方便。



## 执行操作

要执行一个操作，你需要一个能够执行操作的，继承了 `IActionSession` 的会话。例如 `CqHttp Session` 和 `CqWsSession`，均可以用来发送上报。

最基础的方法就是取会话的 ActionSender 然后调用 InvokeActionAsync。它会返回带有对应结果的 Task，等待该 Task，就能得到对应的结果了。

```csharp
// 新建一个发送私聊消息的操作
CqSendPrivateMessageAction action = new CqSendPrivateMessageAction(114514, new CqMessage("这是一条文本消息"));

// 执行操作
CqActionResult? rst = await session.ActionSender.InvokeActionAsync(action);
```

这里所说的对应结果是指，如果你执行的是一个 CqSendPrivateMessageAction，那么它返回的必定是 CqSendPrivateMessageActionResult。其他类型的 Action 也是同理。

如果 InvokeActionAsync 返回了 null，则表示和 Go-CqHttp 的通信出现了问题。要检查调用是否成功，除了判空，你还需要判断结果中返回码的值，他表示 Go-CqHttp 的响应码。

SDK 中，是有提供所有 Action 的拓展方法的，直接对着 session 调用对应的方法即可。例如 `session.SendGroupMessage`。

```csharp
CqSendGroupMessageActionResult? rst = await session.SendGroupMessage(114514, new CqMessage("这是一条文本消息"));
```

