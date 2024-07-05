﻿using CommandLine;

namespace Shwmae {

    class BaseOptions {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }

        [Option("system-dpapi", Required = false, HelpText = "Use a specific SYSTEM DPAPI key")]
        public string SystemDPAPI { get; set; }

        [Option("pin", Required = false, HelpText = "PIN to use for decrypting PIN protector")]
        public string PIN { get; set; }

        [Option("sid", Required = false, HelpText = "Specify a specific account SID to work with")]
        public string SID { get; set; }

        [Option("recovery-token", Required = false, HelpText = "Azure AD access token for cred.microsoft.com resource (used for decrypting recovery keys)")]
        public string RecoveryToken { get; set; }

        [Option("container-path", Required = false, HelpText = "Enumerate Windows Hello containers from a specific folder")]
        public string ContainerPath { get; set; }
    }


    [Verb("enum", isDefault:true, HelpText = "Enumerate Windows Hello protectors, keys and credentials")]
    class EnumOptions : BaseOptions {

    }

    [Verb("sign", HelpText = "Sign data using a Windows Hello protected certificate")]
    class SignOptions : KeyOptions {      
        [Option("data", Required = true, HelpText = "Base64 data that will be decoded and signed")]
        public string Data { get; set; }
    }

    [Verb("dump", HelpText = "Dump Windows Hello protected keys when backed by software")]
    class DumpOptions : KeyOptions {
    }

    class KeyOptions : BaseOptions {
        [Option("key-name", Required = false, HelpText = "Specify which key to work with")]
        public string KeyName { get; set; }
    }

    [Verb("prt", HelpText = "Obtain an Entra PRT and partial TGT usable with Rubeus")]
    class PrtOptions : BaseOptions {
        [Option('g', "generate-keys", Required = false, HelpText = "Generate a new random context and derived key using the Azure device transport certificate")]
        public bool GenerateKeys { get; set; }
    }

    [Verb("webauthn", HelpText = "Create a webserver to proxy WebAuthn requests from an attacking host")]
    class WebAuthnOptions : BaseOptions {

    }
}