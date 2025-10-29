﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message) { }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    /// <summary>
    /// Excepción lanzada cuando no se encuentra una entidad en la base de datos.
    /// </summary>
    public class EntityNotFoundException : DataException
    {
        public string EntityType { get; }
        public object EntityId { get; }

        public EntityNotFoundException(string message)
            : base(message) { }

        public EntityNotFoundException(string entityType, object entityId)
            : base($"La entidad '{entityType}' con ID '{entityId}' no fue encontrada.")
        {
            EntityType = entityType;
            EntityId = entityId;
        }

        public EntityNotFoundException(string entityType, object entityId, Exception innerException)
            : base($"La entidad '{entityType}' con ID '{entityId}' no fue encontrada.", innerException)
        {
            EntityType = entityType;
            EntityId = entityId;
        }
    }

    /// <summary>
    /// Excepción lanzada cuando se intenta realizar una operación que viola reglas de negocio.
    /// </summary>
    public class BusinessRuleViolationException : BusinessException
    {
        public string RuleCode { get; }

        public BusinessRuleViolationException(string message)
            : base(message) { }

        public BusinessRuleViolationException(string ruleCode, string message)
            : base($"Violación de regla de negocio [{ruleCode}]: {message}")
        {
            RuleCode = ruleCode;
        }

        public BusinessRuleViolationException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    /// <summary>
    /// Excepción lanzada cuando se intenta acceder a un recurso sin los permisos adecuados.
    /// </summary>
    public class UnauthorizedAccessBusinessException : BusinessException
    {
        public string Resource { get; }
        public string Operation { get; }

        public UnauthorizedAccessBusinessException(string message)
            : base(message) { }

        public UnauthorizedAccessBusinessException(string resource, string operation)
            : base($"Acceso no autorizado al recurso '{resource}' para la operación '{operation}'.")
        {
            Resource = resource;
            Operation = operation;
        }

        public UnauthorizedAccessBusinessException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    /// <summary>
    /// Excepción lanzada cuando ocurre un error al interactuar con recursos externos.
    /// </summary>
    public class ExternalServiceException : BusinessException
    {
        public string ServiceName { get; }

        public ExternalServiceException(string message)
            : base(message) { }

        public ExternalServiceException(string serviceName, string message)
            : base($"Error en el servicio externo '{serviceName}': {message}")
        {
            ServiceName = serviceName;
        }

        public ExternalServiceException(string serviceName, string message, Exception innerException)
            : base($"Error en el servicio externo '{serviceName}': {message}", innerException)
        {
            ServiceName = serviceName;
        }
    }
}