# 📊 DevAllAnalytics (C# SDK)

**SDK oficial da DevAll Tech para envio de eventos para a plataforma DevAll Analytics.**  
Capture logs, erros, métricas e comportamentos dos seus aplicativos com facilidade em aplicações .NET.

![NuGet](https://img.shields.io/nuget/v/DevAllAnalytics.svg)
![License](https://img.shields.io/badge/license-MIT-blue)

---

## ✨ Recursos

- ✅ Envio de eventos por tipo (error, warning, info, log, etc)
- ✅ Identificação por token do projeto
- ✅ Suporte a múltiplos ambientes (dev, staging, prod)
- ✅ Registro de payloads e informações do dispositivo
- ✅ Leve, simples e pronto para produção

---

## 🚀 Instalação

Via NuGet:

```bash
dotnet add package DevAllAnalytics
```

---

## 🛠️ Como usar

### 1. Inicialize com o token do seu projeto:

```csharp
DevAllAnalytics.Init("SEU_TOKEN_DO_PROJETO");
```

### 2. Envie um evento:

```csharp
await DevAllAnalytics.TrackEventAsync(
    type: DevAllEventType.Error,
    environment: DevAllEnvironment.Dev,
    category: "Login",
    message: "Erro ao autenticar usuário",
    payload: new {
        email = "teste@exemplo.com",
        erro = "Senha inválida"
    },
    deviceInfo: new {
        platform = "Windows",
        osVersion = Environment.OSVersion.ToString(),
        locale = "pt-BR",
        isPhysicalDevice = true
    }
);
```

---

## 🎯 Tipos de Evento

```csharp
public enum DevAllEventType {
    Error,
    Warning,
    Info,
    Log,
    Metric,
    Custom
}
```

---

## 🌐 Ambientes

```csharp
public enum DevAllEnvironment {
    Dev,
    Staging,
    Prod
}
```

---

## 📦 Publicado por [DevAll Tech](https://devalltech.com.br)

Este pacote é mantido oficialmente pela equipe da DevAll Tech.  
Soluções digitais para aplicativos, sistemas e integrações.

---

## 📝 License

MIT License © [DevAll Tech](https://devalltech.com.br)

---

Feito com 💙 por DevAll Tech