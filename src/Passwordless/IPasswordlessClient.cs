﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Passwordless.Models;

namespace Passwordless;

/// <summary>
/// Provides APIs that help you interact with Passwordless.dev.
/// </summary>
public interface IPasswordlessClient
{
    /// <summary>
    /// Creates a register token which will be used by your frontend to negotiate the creation of a WebAuth credential.
    /// </summary>
    Task<RegisterTokenResponse> CreateRegisterTokenAsync(
        RegisterOptions options,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Manually generates an authentication token for the specified user, side-stepping the usual authentication flow.
    /// This approach can be used to implement a "magic link"-style login and other similar scenarios.
    /// </summary>
    Task<AuthenticationTokenResponse> GenerateAuthenticationTokenAsync(
        AuthenticationOptions options,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Verifies that the specified authentication token is valid and returns the information packed into it.
    /// The token should have been generated by calling one of the <c>signInWith*</c> methods from your frontend,
    /// or, in specific scenarios, by calling <see cref="GenerateAuthenticationTokenAsync" /> from the backend.
    /// </summary>
    /// <remarks>
    /// If the token is not valid, an exception of type <see cref="PasswordlessApiException" /> will be thrown.
    /// </remarks>
    Task<VerifiedUser> VerifyAuthenticationTokenAsync(
        string authenticationToken,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets the users count.
    /// </summary>
    Task<UsersCount> GetUsersCountAsync(
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all users in the app.
    /// </summary>
    Task<IReadOnlyList<PasswordlessUserSummary>> ListUsersAsync(
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes the user with the specified ID.
    /// </summary>
    Task DeleteUserAsync(
        string userId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all aliases for the user with the specified ID.
    /// </summary>
    Task<IReadOnlyList<AliasPointer>> ListAliasesAsync(
        string userId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets one or more aliases for an existing user and removes existing aliases
    /// that are not included in the request.
    /// </summary>
    Task SetAliasAsync(
        SetAliasRequest request,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all credentials for the user with the specified ID.
    /// </summary>
    Task<IReadOnlyList<Credential>> ListCredentialsAsync(
        string userId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Attempts to delete a credential with the specified ID.
    /// </summary>
    Task DeleteCredentialAsync(
        string id,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Attempts to delete a credential with the specified ID.
    /// </summary>
    Task DeleteCredentialAsync(
        byte[] id,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets a list of events for the application.  
    /// </summary>
    /// <param name="request"><see cref="GetEventLogRequest"/></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<GetEventLogResponse> GetEventLogAsync(GetEventLogRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends email containing a magic link template allowing users to login.
    /// </summary>
    /// <param name="request"><see cref="SendMagicLinkRequest"/></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SendMagicLinkAsync(SendMagicLinkRequest request, CancellationToken cancellationToken = default);
}