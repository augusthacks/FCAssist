// comment out the whole thing if you don't want to seed the databas

using FCAssist.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FCAssist.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
        {
            // Document Format Options
            if (context == null || context.InvestigationFileFormat == null || context.InvestigationFileContext == null)
            {
                throw new ArgumentNullException("Null FCAssistContext");
            }

            if (context.InvestigationFileFormat.Any())
            {
                return;   // DB has been seeded
            }

            if (context.InvestigationFileContext.Any())
            {
                return;   // DB has been seeded
            }

            context.InvestigationFileFormat.AddRange(
                new FileFormat
                {
                    Format = "Email (pst)"
                },

                new FileFormat
                {
                    Format = "Portable Document Format (PDF)"
                },

                new FileFormat
                {
                    Format = "Word Processor (doc, docx)"
                },

                new FileFormat
                {
                    Format = "Spreadsheet (xlsx, csv)"
                },

                new FileFormat
                {
                    Format = "Picture (png, jpg)"
                },

                new FileFormat
                {
                    Format = "Program File/Executable/Library (exe, dll)"
                },

                new FileFormat
                {
                    Format = "Archive (zip, 7z)"
                },

                new FileFormat
                {
                    Format = "Raw Digital Forensic File (e01, dd, img)"
                },

                new FileFormat
                {
                    Format = "Logical Digital Forensic File (axiom, aut)"
                }
            );

            // Document Context Options
            if (context.InvestigationFileContext.Any())
            {
                return;   // DB has been seeded
            }

            context.InvestigationFileContext.AddRange(
                new FileContext
                {
                    Context = "Communication"
                },
                
                new FileContext
                {
                    Context = "Evidence"
                },

                new FileContext
                {
                    Context = "Judicial Authorization"
                },

                new FileContext
                {
                    Context = "SIENA"
                },

                new FileContext
                {
                    Context = "Note"
                },

                new FileContext
                {
                    Context = "Report"
                },

                new FileContext
                {
                    Context = "Screen Capture"
                },

                new FileContext
                {
                    Context = "Photograph"
                },

                new FileContext
                {
                    Context = "Malware"
                },

                new FileContext
                {
                    Context = "Logs"
                },

                new FileContext
                {
                    Context = "Administrative"
                }
            );
            context.SaveChanges();
        }
    }
}

