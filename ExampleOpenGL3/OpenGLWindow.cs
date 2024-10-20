﻿namespace ExampleOpenGL3
{
    using ExampleFramework;
    using ExampleFramework.ImGuiDemo;
    using ExampleFramework.ImGuizmoDemo;
    using ExampleFramework.ImNodesDemo;
    using ExampleFramework.ImPlotDemo;
    using Hexa.NET.ImGui;
    using Hexa.NET.ImGui.Backends;
    using Hexa.NET.ImGui.Backends.GLFW;
    using Hexa.NET.ImGui.Backends.OpenGL3;
    using Hexa.NET.ImGui.Backends.SDL2;
    using Silk.NET.Core.Contexts;
    using Silk.NET.OpenGL;
    using Silk.NET.SDL;

    public unsafe class OpenGLWindow : CoreWindow, IGLContextSource
    {
        private void* glcontext;
        private SDLGLContext context;
        private GL gl;

        private ImGuiManager imGuiManager;
        private ImGuiDemo imGuiDemo;
        private ImGuizmoDemo imGuizmoDemo;
        private ImNodesDemo imNodesDemo;
        private ImPlotDemo imPlotDemo;

        public IGLContext? GLContext { get; }

        public override void InitGraphics()
        {
            glcontext = sdl.GLCreateContext(SDLWindow);
            context = new(SDLWindow, glcontext, null);
            gl = GL.GetApi(context);

            imGuiManager = new();
            imGuiManager.OnRenderDrawData += OnRenderDrawData;

            ImGuiImplSDL2.InitForOpenGL((SDLWindow*)SDLWindow, glcontext);
            App.RegisterHook(ProcessEvent);

            ImGuiImplGLFW.SetCurrentContext(ImGui.GetCurrentContext());

            ImGuiImplOpenGL3.SetCurrentContext(ImGui.GetCurrentContext());
            ImGuiImplOpenGL3.Init((string)null!);
            ImGuiImplOpenGL3.NewFrame();

            imGuiDemo = new();
            imGuizmoDemo = new();
            imNodesDemo = new();
            imPlotDemo = new();
        }

        private void OnRenderDrawData()
        {
            ImGuiImplOpenGL3.NewFrame();
            ImGuiImplOpenGL3.RenderDrawData(ImGui.GetDrawData());
        }

        public override void Render()
        {
            imGuiManager.NewFrame();
            ImGui.ShowDemoWindow();
            imGuizmoDemo.Draw();
            imNodesDemo.Draw();
            imPlotDemo.Draw();

            context.MakeCurrent();
            gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
            gl.Clear((uint)ClearBufferMask.ColorBufferBit | (uint)ClearBufferMask.DepthBufferBit);

            imGuiManager.EndFrame();

            context.MakeCurrent();
            context.SwapBuffers();
        }

        private static bool ProcessEvent(Event @event)
        {
            return ImGuiImplSDL2.ProcessEvent((SDLEvent*)&@event);
        }

        private bool disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                App.RemoveHook(ProcessEvent);
                ImGuiImplOpenGL3.Shutdown();
                ImGuiImplSDL2.Shutdown();
                imGuiManager.Dispose();
                context.Dispose();
                gl.Dispose();
                base.Dispose(disposing);
                disposed = true;
            }
        }
    }
}