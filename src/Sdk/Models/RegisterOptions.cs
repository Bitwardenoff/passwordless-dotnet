﻿namespace Passwordless.Net;

/// <summary>
/// 
/// </summary>
public class RegisterOptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="username"></param>
    public RegisterOptions(string userId, string username)
    {
        UserId = userId;
        Username = username;
    }

    /// <summary>
    /// A WebAuthn User Handle, which should be generated by your application.
    /// This is used to identify your user (could be a database primary key ID or a guid).
    /// Max. 64 bytes. Should not contain PII about the user.
    /// </summary>
    public string UserId { get; }

    /// <summary>
    /// A human-palatable identifier for a user account. It is intended only for display,
    /// i.e., aiding the user in determining the difference between user accounts with
    /// similar displayNames. Used in Browser UI's and never stored on the server.
    /// </summary>
    public string Username { get; }

    /// <summary>
    /// A human-palatable name for the account, which should be chosen by the user.
    /// Used in Browser UI's and never stored on the server.
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// WebAuthn attestation conveyance preference. Only "none" (default) is supported.
    /// </summary>
    public string? Attestation { get; set; }

    /// <summary>
    /// WebAuthn authenticator attachment modality. Can be "any" (default), "platform",
    /// which triggers client device-specific options Windows Hello, FaceID, or TouchID,
    /// or "cross-platform", which triggers roaming options like security keys.
    /// </summary>
    public string? AuthenticatorType { get; set; }

    /// <summary>
    /// If true, creates a client-side Discoverable Credential that allows sign in without needing a username.
    /// </summary>
    public bool? Discoverable { get; set; }

    /// <summary>
    /// Allows choosing preference for requiring User Verification
    /// (biometrics, pin code etc) when authenticating Can be "preferred" (default), "required" or "discouraged".
    /// </summary>
    public string? UserVerification { get; set; }

    /// <summary>
    /// Timestamp (UTC) when the registration token should expire. By default, current time + 120 seconds.
    /// </summary>
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// A array of aliases for the userId, such as an email or username. Used to initiate a
    /// signin on the client side with the signinWithAlias() method. An alias must be unique to the userId.
    /// Defaults to an empty array [].
    /// </summary>
    public HashSet<string> Aliases { get; set; } = new HashSet<string>();

    /// <summary>
    /// Whether aliases should be hashed before being stored. Defaults to true.
    /// </summary>
    public bool? AliasHashing { get; set; }
}
