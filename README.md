# InsecurePowerShellHost

InsecurePowerShellHost is a .NET Core host process for [InsecurePowerShell](https://github.com/cobbr/InsecurePowerShell), a version of PowerShell Core with key security features removed.

## InsecurePowerShell

InsecurePowershell is a fork of PowerShell Core v6.0.0, with key security features removed. InsecurePowerShell removes the following security features from PowerShell:

* AMSI - `InsecurePowerShell` does not submit any PowerShell code to the AMSI, even when there is an actively listening AntiMalware Provider.
* PowerShell Logging - `InsecurePowerShell` disables ScriptBlockLogging, Module Logging, and Transcription Logging. Even if they are enabled in Group Policy, these settings are ignored.
* LanguageModes - `InsecurePowerShell` always runs PowerShell code in `FullLanguage` mode. Attempting to set `InsecurePowerShell` to alternative LanguageModes, such as `ConstrainedLanguage` mode or `RestrictedLanguage` mode does not take any affect.
* ETW - `InsecurePowerShell` does not utilize ETW (Event Tracing for Windows).

More details are available [here](https://cobbr.io).
