# SIFRO CRM
microsservice para gestão de frotas crm


* Em vez de um sistema único (monolito), dividimos o CRM em módulos independentes, cada um com seu banco de dados,  lógica e API.

## Microsserviços sugeridos

### Serviço de Clientes

* -> Cadastro de alunos

* -> Cadastro de responsáveis (pais/mães/tutores).

* -> Histórico de interações.

### Serviço de Operações

* -> Motoristas e veículos.

* -> Rotas e pontos de embarque/desembarque.

* -> Controle de horários.

### Serviço Financeiro

* -> Planos e mensalidades.

* -> Pagamentos e recibos.

* -> Notificação de inadimplência.

### Serviço de Comunicação

* -> Envio de notificações (e-mail, SMS, WhatsApp).

* -> Alertas em tempo real (ex.: “Seu filho chegou na escola”).

### Serviço de Relatórios/BI

* -> Dashboards de ocupação de rotas.

* -> Relatórios financeiros.

* -> Indicadores de fidelização (renovação de contratos).

## Arquitetura Tecnológica

CQRS + Event Sourcing se quiser evoluir para alta escalabilidade.

API Gateway → Ponto único de entrada para expor os microsserviços.

Backend de cada serviço → .NET 8 com Clean Architecture (cada microsserviço tem seu contexto e banco).

Banco de dados: SQL Server ou PostgreSQL (por serviço).

Mensageria → RabbitMQ, Kafka ou Azure Service Bus (para comunicação assíncrona entre serviços).

Frontend (painel web) → React.js consumindo o API Gateway.

Mobile (futuro) → App em React Native ou Flutter para pais e motoristas.

### fluxo dos Serviços

* O Serviço de Clientes recebe o cadastro do aluno + responsável.

* O Serviço de Operações define a rota para esse aluno.

* O Serviço Financeiro gera a cobrança mensal.

* O Serviço de Comunicação envia lembretes de pagamento e notifica a chegada do aluno.

* O Serviço de Relatórios consolida tudo e mostra ao gestor: rotas mais cheias, atrasos de pagamento, etc.
